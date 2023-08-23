import { Component, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AddOrderComponent } from './components/add-order/add-order.component';
import { FormsModule } from '@angular/forms';
import { MainAppComponent } from './components/main-app/main.component';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
    MainAppComponent,
    AddOrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [ 
    AppComponent
  ]
})
export class AppModule { }
