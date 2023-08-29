namespace WebShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime _Date { get; set; }
        //public List<ProductSize> ProductSizes { get; set; }
    }
}
