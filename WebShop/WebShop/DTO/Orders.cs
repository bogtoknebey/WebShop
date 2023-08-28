using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using WebShop.Models;
using WebShop.DTO.Views;
using System.Collections.Generic;
using WebShop.DTO.Interfaces;

namespace WebShop.DTO
{
    public class Orders : IGetAll<Order>, IGetView<OrderView>
    {
        private AppDbContext db;
        public Orders(AppDbContext db)
        {
            this.db = db;
        }

        public List<Order> GetAll() 
        {
            List<Order> allOrders = db.Orders
                .Include(o => o.Customer)
                .Include(o => o.ProductOrders)
                .ThenInclude(po => po.ProductSize)
                .ThenInclude(po => po.Product)
                .ToList();

            // Exclude circular references in child properties
            foreach (var order in allOrders)
            {
                order.Customer.Orders = null;
                foreach (var productOrder in order.ProductOrders)
                {
                    productOrder.ProductSize.ProductOrders = null;
                    productOrder.ProductSize.Product.ProductSizes = null;
                    productOrder.Order = null;
                }
            }

            return allOrders;
        }

        public List<OrderView> GetAllViews()
        {
            List<Order> allOrders = GetAll();
            List<OrderView> allOrdersView = new List<OrderView>();

            foreach (var order in allOrders)
            {
                int id = order.Id;
                string customerName = order.Customer.Name;
                string customerAddress = order.Customer.Address;
                string status = order.Status;
                
                double totalCost = 0;
                foreach (var productOrder in order.ProductOrders)
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
    }
}
