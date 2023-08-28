import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


class OrderView {
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

class ProductView {
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


@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})

export class OrdersComponent implements OnInit {
    addPage: boolean = false;
    orderViews: OrderView[] = [];
    productViews: ProductView[] = [];

    constructor(private http: HttpClient){
      this.addPage = false;
    }


    ngOnInit(): void {
      this.setOrders();
    }


    setOrders(): void {
      this.http.get('https://localhost:7011/api/orders')
        .subscribe(
          (response: any) => {
            this.orderViews = response;
          },
          error => {
            console.error('Error fetching data:', error);
          }
        );
    }

    setProducts(): void {
      this.http.get('https://localhost:7011/api/products')
        .subscribe(
          (response: any) => {
            this.productViews = response;
          },
          error => {
            console.error('Error fetching data:', error);
          }
        );
    }


    switchPage() {
      this.addPage = !this.addPage;
      if (this.addPage) {
        this.setProducts();
      } else {
        this.setOrders();
      }
    }
}
