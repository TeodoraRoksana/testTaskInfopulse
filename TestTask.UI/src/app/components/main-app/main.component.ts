import { Component } from '@angular/core';
import { Order } from 'src/app/models/order';
import { OrdersService } from 'src/app/services/orders.service';


@Component({
  selector: 'main-root',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainAppComponent {
  title = 'TestTask.UI';
  orders: Order[] = [];
  
  

  constructor(private orderService: OrdersService) {}

  ngOnInit() : void{
    this.orderService
      .getOrders()
      .subscribe((result: Order[]) => { 
        this.orders = result;
       console.log(result);
      });      
  }

}
