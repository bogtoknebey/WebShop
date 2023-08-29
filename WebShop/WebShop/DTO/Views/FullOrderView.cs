using WebShop.Models;

namespace WebShop.DTO.Views
{
    public class FullOrderView
    {
        public Order Order { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
