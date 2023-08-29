export class AddProductOrderView {
    Id?: number;
    OrderId?: number;
    ProductSizeId: number;
    Quantity: number;

    Name: string = "";
    constructor (ProductSizeId: number, Quantity: number) {
      this.ProductSizeId = ProductSizeId;
      this.Quantity = Quantity;
    }
}