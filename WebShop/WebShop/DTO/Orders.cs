﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using WebShop.Models;
using System.Collections.Generic;
using WebShop.DTO.Interfaces;
using WebShop.Views;
using WebShop.Views.Add;

namespace WebShop.DTO
{
    public class Orders : IGetAll<FullOrderView>, IGetView<OrderView>
    {
        private AppDbContext db;
        public Orders(AppDbContext db)
        {
            this.db = db;
        }

        public List<FullOrderView> GetAll() 
        {
            List<Order> allOrders = db.Orders.
                Include(o => o.Customer).
                ToList();
            List<FullOrderView> allViews = new List<FullOrderView>();
            foreach (var order in allOrders)
            {
                List<ProductOrder> productOrders = db.ProductOrders.
                    Where(po => po.OrderId == order.Id).
                    Include(po => po.ProductSize).
                    ThenInclude(po => po.Product).
                    ToList();

                // delete back ralation links
                foreach (var productOrder in productOrders)
                    productOrder.Order = null;

                FullOrderView view = new FullOrderView()
                {
                    Order = order,
                    ProductOrders = productOrders
                };
                allViews.Add(view);
            }

            return allViews;
        }

        public List<OrderView> GetAllViews()
        {
            List<FullOrderView> allFullOrders = GetAll();
            List<OrderView> allOrdersView = new List<OrderView>();

            foreach (var fullOrderView in allFullOrders)
            {
                int id = fullOrderView.Order.Id;
                string customerName = fullOrderView.Order.Customer.Name;
                string customerAddress = fullOrderView.Order.Customer.Address;
                string status = fullOrderView.Order.Status;
                
                double totalCost = 0;
                foreach (var productOrder in fullOrderView.ProductOrders)
                {
                    totalCost += productOrder.Quantity * productOrder.ProductSize.Price;
                }

                OrderView currView = new OrderView() 
                { 
                    Id = id, 
                    CustomerName = customerName,
                    CustomerAddress = customerAddress,
                    TotalCost = totalCost,
                    Status = status,
                };
                allOrdersView.Add(currView);
            }

            return allOrdersView;
        }
        public int GetNewId()
        {
            return db.Orders.Max(o => o.Id) + 1;
        }

        public int GetNewProductOrderId()
        {
            return db.ProductOrders.Max(o => o.Id) + 1;
        }

        public bool AddOrder(AddOrderView newOrderView)
        {
            // order add
            Order order = new Order
            {
                CustomerId = newOrderView.CustomerId,
                Status = newOrderView.Status,
                Comment = newOrderView.Comment,
                _Date = DateTime.Now.Date
            };
            db.Orders.Add(order);
            db.SaveChanges();

            // ProductOrders add
            foreach (var productOrderView in newOrderView.ProductOrders)
            {
                ProductOrder productOrder = new ProductOrder
                {
                    OrderId = order.Id,
                    ProductSizeId = productOrderView.ProductSizeId,
                    Quantity = productOrderView.Quantity
                };
                db.ProductOrders.Add(productOrder);

                // put request to ProductSize
                CangeProductSizeQuantity(productOrder.ProductSizeId, productOrder.Quantity);
            }

            db.SaveChanges();
            return true;
        }

        public bool CangeProductSizeQuantity(int id, int reduction)
        {
            if (!db.ProductSizes.Any(p => p.Id == id))
                return false;

            var existingProduct = db.ProductSizes.Find(id);

            if (existingProduct == null)
                return false;

            int newQuantity = existingProduct.Quantity - reduction;
            if (newQuantity < 0)
                return false;

            existingProduct.Quantity = newQuantity;

            db.SaveChanges();
            return true;
        }
    }
}
