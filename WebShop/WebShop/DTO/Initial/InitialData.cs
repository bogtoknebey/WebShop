using WebShop.Models;

namespace WebShop.DTO.Initial
{
    public class InitialData
    {
        private static DateTime today = DateTime.Now.Date;
        public static List<Customer> Customers { get; set; } = new List<Customer>()
        {
            new Customer
            {
                Id = 1,
                Name = "John Smith",
                Address = "5th Ave, New York",
               _Date = today

            },
            new Customer
            {
                Id = 2,
                Name = "Adam Tailor",
                Address = "9th Ave, Seattle",
                _Date = today

            }
        };

        public static List<Order> Orders { get; set; } = new List<Order>()
        {
            new Order
            {
                Id = 1,
                CustomerId = 1,
                Status = "New",
                Comment = "I like it",
                _Date = today
            },
            new Order
            {
                Id = 2,
                CustomerId = 1,
                Status = "New",
                Comment = "I like it",
                _Date = today
            },
            new Order
            {
                Id = 3,
                CustomerId = 2,
                Status = "New",
                Comment = "I take a try",
                _Date = today
            }
        };
        public static List<ProductSize> ProductSizes { get; set; } = new List<ProductSize>()
        {
            new ProductSize
            {
                Id = 1,
                ProductId = 1,
                Size = "small",
                Quantity = 20,
                Price = 30.0
            },
            new ProductSize
            {
                Id = 2,
                ProductId = 1,
                Size = "medium",
                Quantity = 10,
                Price = 50.0
            },
            new ProductSize
            {
                Id = 3,
                ProductId = 2,
                Size = "medium",
                Quantity = 20,
                Price = 40.0
            },
            new ProductSize
            {
                Id = 4,
                ProductId = 2,
                Size = "large",
                Quantity = 15,
                Price = 60.0
            }
        };
        public static List<Product> Products { get; set; } = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Pizza",
                Category = "Foods",
                Description = "Italian pizza",
                _Date = today
            },
            new Product
            {
                Id = 2,
                Name = "Chocolate",
                Category = "Foods",
                Description = "Swiss chocolate",
                _Date = today
            }
        };
        public static List<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>()
        {
            new ProductOrder
            {
                Id = 1,
                OrderId = 1,
                ProductSizeId = 1,
                Quantity = 2
            },
            new ProductOrder
            {
                Id = 2,
                OrderId = 1,
                ProductSizeId = 2,
                Quantity = 1
            },
            new ProductOrder
            {
                Id = 3,
                OrderId = 2,
                ProductSizeId = 2,
                Quantity = 2
            },
            new ProductOrder
            {
                Id = 4,
                OrderId = 3,
                ProductSizeId = 1,
                Quantity = 1
            },
            new ProductOrder
            {
                Id = 5,
                OrderId = 3,
                ProductSizeId = 4,
                Quantity = 10
            }
        };
    }
}
