import { NgFor } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { Order } from 'src/app/models/order';

import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { Customer } from 'src/app/models/customer';
import { CustomersService } from 'src/app/services/customers.service';
import { Router } from '@angular/router';
import { Status } from 'src/app/models/status';
import { StatusesService } from 'src/app/services/statuses.service';
import { Product } from 'src/app/models/product';
import { ProductsService } from 'src/app/services/products.service';
import { ProductInOrder } from 'src/app/models/productInOrder';
import { OrdersService } from 'src/app/services/orders.service';

@Component({
  selector: 'app-add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css'],
  //standalone: true,
  //imports: [FormsModule, MatFormFieldModule, MatSelectModule, NgFor, MatInputModule]
})

// @Component({
//   selector: 'select-form-example',
//   templateUrl: 'select-form-example.html',
//   standalone: true,
//   imports: [FormsModule, MatFormFieldModule, MatSelectModule, NgFor, MatInputModule],
// })

 export class AddOrderComponent implements OnInit {
  customers: Customer[] = [];
  statuses: Status[] = [];
  products: Product[] = [];
  newOrder = new Order;
  idOrder = 0;
  orders:Order[] = [];
  @Output() orderAdded = new EventEmitter<Order[]>();


  constructor(private customerService: CustomersService, 
              private statusesService: StatusesService,
              private productsService: ProductsService,
              private orderService: OrdersService,
              private router: Router) { }

  ngOnInit(): void {
    this.customerService
      .getCustomers()
      .subscribe((result: Customer[]) => { 
        this.customers = result;
      });
    
    this.statusesService
      .getStatues()
      .subscribe((result: Status[]) => {
        this.statuses = result;
      });

      this.productsService
      .getProducts()
      .subscribe((result: Product[]) => {
        this.products = result;
      });
      
  }

  addProductsToOrder(){
    let product = this.products[0];
    this.newOrder.productsInOrder.push(new ProductInOrder);
    let iterator = this.newOrder.productsInOrder.length - 1;
    this.newOrder.productsInOrder[iterator].product = product;
    this.newOrder.productsInOrder[iterator].orderQuantity = 1;
    this.newOrder.productsInOrder[iterator].productSize.productSizeId = 1;
    this.newOrder.productsInOrder[iterator].productSize.name = "Small";

    this.newOrder.totalCost += this.newOrder.productsInOrder[iterator].product.price;
    console.log(this.newOrder.productsInOrder);
  }

  saveOrder(newOrder: Order){
    let customer = this.customers.find(p => p.customerId == newOrder.client.customerId);
    if(customer != null){
      newOrder.client.address = customer.address;
      newOrder.client.name = customer.name;
      newOrder.client.date = customer.date;
      newOrder.client.ordersCount = customer.ordersCount;
    }
    
    this.orderService
      .postNewOrder(newOrder)
      .subscribe((result: Order[]) => {
        this.orderAdded.emit(result);
        console.log(result);
      });

      this.router.navigate(['/']);
  }

  cancel(){
    this.router.navigate(['/']);
  }


}
