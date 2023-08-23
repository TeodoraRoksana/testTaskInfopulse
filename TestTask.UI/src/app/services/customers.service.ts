import { Injectable } from '@angular/core';
import { Order } from '../models/order';
import { Customer } from '../models/customer';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {
  private url = "Customer";

  constructor(private http: HttpClient) { }

  // public getOrders() : Order[]{
  //   let customer = new Customer();
  //   customer.id = 1;
  //   customer.Name = "Tom";
  //   customer.Date = "02-07-2023";
  //   customer.Address = "New York";
  //   customer.OrdersCount = 0;

  //   let order = new Order();
  //   order.id = 1;
  //   order.Date = "08.08.2023";
  //   order.Customer = customer;
  //   order.Status = "New";
  //   order.TotalCost = 50;
  //   order.Comment = "Hi";
  //   order.Products = [1, 2, 3];

  //   return [order];
  // }

  public getCustomers() : Observable<Customer[]>{
    return this.http.get<Customer[]>(`https://localhost:7168/api/${this.url}`);
  }
}
