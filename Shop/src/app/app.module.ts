import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; 
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { OrdersAddComponent } from './components/orders-add/orders-add.component';
import { OrdersViewComponent } from './components/orders-view/orders-view.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    OrdersAddComponent,
    OrdersViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
