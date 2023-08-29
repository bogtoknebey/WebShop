import { AddProductOrderView } from './AddProductOrderView';

export class AddOrderView {
    Id?: number;
    CustomerId: number;
    Status: string;
    date?: Date;
    Comment: string;
    ProductOrders: AddProductOrderView[];
  
    constructor (CustomerId: number, Status: string, Comment: string, ProductOrders: AddProductOrderView[]) {
      this.CustomerId = CustomerId;
      this.Status = Status;
      this.Comment = Comment;
      this.ProductOrders = ProductOrders;

      // empty data
      this.Id = 0;
      this.date = new Date();
    }
}
  