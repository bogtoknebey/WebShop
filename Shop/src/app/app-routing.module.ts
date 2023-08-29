import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersAddComponent } from './components/orders-add/orders-add.component';
import { OrdersViewComponent } from './components/orders-view/orders-view.component';

const routes: Routes = [
  { path: '', component: OrdersViewComponent }, 
  { path: 'orders', component: OrdersViewComponent },
  { path: 'orders/add', component: OrdersAddComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
