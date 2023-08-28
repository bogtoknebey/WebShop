using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShop.DTO.Initial;
using WebShop.DTO;
using WebShop.Models;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public Orders orders { get; set; }
        public OrdersController(AppDbContext db)
        {
            orders = new Orders(db);
        }

        [HttpGet]
        public string Index()
        {
            return JsonConvert.SerializeObject(orders.GetAllViews());
        }
    }
}
