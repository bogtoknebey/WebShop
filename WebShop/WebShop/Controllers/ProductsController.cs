using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShop.DTO;
using WebShop.Models;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public Products products { get; set; }
        public ProductsController(AppDbContext db)
        {
            products = new Products(db);
        }

        [HttpGet]
        public string Index()
        {
            return JsonConvert.SerializeObject(products.GetAllViews());
        }
    }
}
