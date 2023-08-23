import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private url = "Products";

  constructor(private http: HttpClient) { }

  public getProducts() : Observable<Product[]>{
    return this.http.get<Product[]>(`https://localhost:7168/api/${this.url}`);
  }
}
