export class AddProductOrderView {
    Id?: number = 0;
    OrderId?: number = 0;
    ProductSizeId: number;
    Quantity: number;
    constructor (ProductSizeId: number, Quantity: number) {
      this.ProductSizeId = ProductSizeId;
      this.Quantity = Quantity;

      // empty data
      this.Id = 0;
      this.OrderId = 0;
    }
}