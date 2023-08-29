using Microsoft.EntityFrameworkCore;
using WebShop.DTO.Interfaces;
using WebShop.DTO.Views;
using WebShop.Models;

namespace WebShop.DTO
{
    public class Customers : IGetAll<Customer>, IGetView<CustomerView>
    {
        private AppDbContext db;
        public Customers(AppDbContext db)
        {
            this.db = db;
        }

        public List<Customer> GetAll()
        {
            List<Customer> allCustomers = db.Customers.
                ToList();
            return allCustomers;
        }

        public List<CustomerView> GetAllViews()
        {
            List<Customer> allCustomers = GetAll();
            List<CustomerView> allViews = new List<CustomerView>();
            foreach (var customer in allCustomers)
            {
                CustomerView view = new CustomerView() 
                {
                    Id = customer.Id,
                    Name = customer.Name,
                };
                allViews.Add(view);
            }

            return allViews;
        }
    }
}
