namespace WebShop.Views.Add
{
    public class AddOrderView
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public List<AddProductOrderView> ProductOrders { get; set; }
    }
}
