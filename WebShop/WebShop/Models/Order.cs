namespace WebShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime _Date { get; set; }
        public Customer Customer { get; set; }
        //public List<ProductOrder> ProductOrders { get; set; }
    }
}
