export class OrderView {
  Id: number;
  CustomerName: string;
  CustomerAddress: string;
  TotalCost: number;
  Status: string;

  constructor(Id: number, CustomerName: string, CustomerAddress: string, TotalCost: number, Status: string) {
    this.Id = Id;
    this.CustomerName = CustomerName;
    this.CustomerAddress = CustomerAddress;
    this.TotalCost = TotalCost;
    this.Status = Status;
  }
}