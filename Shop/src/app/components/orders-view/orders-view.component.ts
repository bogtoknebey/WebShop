import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { OrderView } from './Views/OrderView';


@Component({
  selector: 'app-orders-view',
  templateUrl: './orders-view.component.html',
  styleUrls: ['./orders-view.component.css']
})

export class OrdersViewComponent implements OnInit {
  // Link
  baseLink:string = 'https://localhost:7011/api';

  orderViews: OrderView[] = [];

  constructor(private http: HttpClient, private router: Router){
  }


  ngOnInit(): void {
    this.setOrders();
  }


  setOrders(): void {
    this.http.get(`${this.baseLink}/orders`)
      .subscribe(
        (response: any) => {
          this.orderViews = response;
        },
        error => {
          console.error('Error fetching data:', error);
        }
      );
  }

  // Handlers

  switchToAddOrders() {
    this.router.navigate(['/orders/add']);
  }
}
