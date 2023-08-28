namespace WebShop.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int ProductSizeId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public ProductSize ProductSize { get; set; }
    }
}
