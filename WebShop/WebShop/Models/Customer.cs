namespace WebShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime _Date { get; set; }
        public List<Order> Orders { get; set; }
    }
}
