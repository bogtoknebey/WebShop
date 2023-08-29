import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CustomerView } from './Views/CustomerView';
import { ProductView } from './Views/ProductView';
import { AddOrderView } from './Views/AddOrderView';
import { AddProductOrderView } from './Views/AddProductOrderView';



@Component({
  selector: 'app-orders-add',
  templateUrl: './orders-add.component.html',
  styleUrls: ['./orders-add.component.css']
})
export class OrdersAddComponent implements OnInit {
  // Link
  baseLink:string = 'https://localhost:7011/api';
 
  // Data
  productViews: ProductView[] = [];
  orderId:number = 0;
  date: Date = new Date();
  customers: CustomerView[] = [];
  selectedCustomer: number = 0;
  selectedStatus: string = "";
  totalCost: number = 0;
  comment: string = "";

  // Validation data
  statusValid: boolean = false;
  customerValid: boolean = false;
  isAllValid: boolean = true;
  invalidMessage: string = "";

  constructor(private http: HttpClient, private router: Router){
    this.statusValid = false;
    this.customerValid = false;
    this.isAllValid = true;
  }

  ngOnInit(): void {
    this.setProducts();
    this.setOrderId();
    this.date = new Date();
    this.setCustomers();
  }

  // Data settings

  setProducts(): void {
    this.http.get(`${this.baseLink}/products`)
      .subscribe(
        (response: any) => {
          this.productViews = response;
          console.log(this.productViews);
          
          // reduce quantity (for test product list) and then set total cost
          this.productViews.forEach(product => {
            product.Quantity = 2;
          });

          this.setTotalCost();
        },
        error => {
          console.error('Error fetching data:', error);
        }
      );
  }

  setOrderId(): void{
    this.http.get(`${this.baseLink}/orders/newid`)
    .subscribe(
      (response: any) => {
        this.orderId = response;
      },
      error => {
        console.error('Error fetching data:', error);
      }
    );
  }

  setCustomers(): void{
    this.http.get(`${this.baseLink}/customers`)
    .subscribe(
      (response: any) => {
        this.customers = response;
      },
      error => {
        console.error('Error fetching data:', error);
      }
    );
  }

  setTotalCost(): void {
    this.totalCost = 0;
    this.productViews.forEach(product => {
      this.totalCost += product.Quantity * product.Price;
    });
  }

  addOrder(): void {
    // validation checks
    this.isAllValid = true;
    this.invalidMessage = "Please, ";
    if (!this.statusValid) {
      this.isAllValid = false;
      this.invalidMessage += "*select status ";
    }
    if (!this.customerValid) {
      this.isAllValid = false;
      this.invalidMessage += "*select customer ";
    }
    if (this.productViews.length == 0) {
      this.isAllValid = false;
      this.invalidMessage += "*add any products ";
    }
    if (!this.isAllValid)
      return;

    // form order
    let productOrders: AddProductOrderView[] = [];
    this.productViews.forEach(product => {
      productOrders.push(new AddProductOrderView(product.Id, product.Quantity))
    });
    let order: AddOrderView = new AddOrderView (
      this.selectedCustomer,
      this.selectedStatus,
      this.comment,
      productOrders
    )

    console.log(order);
    this.http.post(`${this.baseLink}/orders`, order).subscribe( 
      response => {
        console.log('Request successful:', response);
      },
      error => {
        console.error('Request error:', error);
      }
    );
    
    setTimeout(() => {
      this.switchToViewOrders();
    }, 500);
    
    
    
  }


  // Handlers

  switchToViewOrders() {
    this.router.navigate(['/orders']);
  }

  switchStatus(event: any) {
    let value = event.target.value;
    this.selectedStatus = value;

    if (value == "New" || value == "Paid")
      this.statusValid = true;
    else
      this.statusValid = false;

    console.log("statusValid: " + this.statusValid);
  }

  switchCustomer(event: any) {
    let value = event.target.value;
    this.selectedCustomer = value;

    this.customerValid = true;
    console.log("statusValid: " + this.customerValid);
  }
}
