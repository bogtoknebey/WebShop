using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShop.DTO.Initial;
using WebShop.DTO;
using WebShop.Models;
using WebShop.Views.Add;

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

        [HttpGet("newid")]
        public string GetNewId()
        {
            return JsonConvert.SerializeObject(orders.GetNewId());
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] AddOrderView newOrder)
        {
            if (newOrder == null)
                return BadRequest("Invalid order data");

            if (orders.AddOrder(newOrder))
                return Ok();
            else
                return BadRequest("Failed to add");
        }
    }
}
