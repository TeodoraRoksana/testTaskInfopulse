import { Injectable } from '@angular/core';
import { Order } from '../models/order';
import { Customer } from '../models/customer';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private url = "Order";

  constructor(private http: HttpClient) { }


  public getOrders() : Observable<Order[]>{
    return this.http.get<Order[]>(`https://localhost:7168/api/${this.url}`);
  }

  public postNewOrder(newOrder: Order) : Observable<Order[]>{
    return this.http.post<Order[]>(`https://localhost:7168/api/${this.url}`, newOrder);
  }
}
