export class ProductView {
  Id: number;
  Name: string;
  Category: string;
  Size: string;
  Quantity: number;
  Price: number;

  constructor (Id: number, Name: string, Category: string, Size: string, Quantity: number, Price: number) {
    this.Id = Id;
    this.Name = Name;
    this.Category = Category;
    this.Size = Size;
    this.Quantity = Quantity;
    this.Price = Price;
  }
}