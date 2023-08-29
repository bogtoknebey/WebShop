using Microsoft.EntityFrameworkCore;
using WebShop.DTO.Views;
using WebShop.Models;
using WebShop.DTO.Views;
using WebShop.DTO.Interfaces;

namespace WebShop.DTO
{
    public class Products : IGetAll<ProductSize>, IGetView<ProductView>
    {
        private AppDbContext db;
        public Products(AppDbContext db)
        {
            this.db = db;
        }
        public List<ProductSize> GetAll()
        {
            List<ProductSize> res = db.ProductSizes.
                Include(o => o.Product).
                ToList();
            return res;
        }
        public List<ProductView> GetAllViews()
        {
            List<ProductSize> allProducts = GetAll();
            List<ProductView> allProductsView = new List<ProductView>();

            foreach (var product in allProducts)
            {
                ProductView currView = new ProductView()
                {
                    Id = product.Id,
                    Name = product.Product.Name,
                    Category = product.Product.Category,
                    Size = product.Size,
                    Quantity = product.Quantity,
                    Price = product.Price
                };
                allProductsView.Add(currView);
            }

            return allProductsView;
        }
    }
}
