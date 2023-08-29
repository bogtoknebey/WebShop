using Microsoft.EntityFrameworkCore;
using WebShop.Models;
using WebShop.DTO.Initial;


namespace WebShop.DTO
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public void ResetDatabase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(InitialData.Customers);
            modelBuilder.Entity<Order>().HasData(InitialData.Orders);
            modelBuilder.Entity<ProductSize>().HasData(InitialData.ProductSizes);
            modelBuilder.Entity<Product>().HasData(InitialData.Products);
            modelBuilder.Entity<ProductOrder>().HasData(InitialData.ProductOrders);
        }
    }
}
