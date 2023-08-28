using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShop.DTO;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public Customers customers { get; set; }
        public CustomersController(AppDbContext db)
        {
            customers = new Customers(db);
        }

        [HttpGet]
        public string Index()
        {
            return JsonConvert.SerializeObject(customers.GetAllViews());
        }
    }
}
