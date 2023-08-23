import { Injectable } from '@angular/core';
import { Order } from '../models/order';
import { Customer } from '../models/customer';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment.development';
import { Status } from '../models/status';

@Injectable({
  providedIn: 'root'
})
export class StatusesService {
  private url = "Status";

  constructor(private http: HttpClient) { }

  public getStatues() : Observable<Status[]>{
    return this.http.get<Status[]>(`https://localhost:7168/api/${this.url}`);
  }
}
