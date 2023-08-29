using WebShop.Models;

namespace WebShop.Views
{
    public class FullOrderView
    {
        public Order Order { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
    }
}
