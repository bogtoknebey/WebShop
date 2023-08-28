namespace WebShop.DTO.Views
{
    public class OrderView
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public double TotalCost { get; set; }
        public string Status { get; set; }
    }
}
