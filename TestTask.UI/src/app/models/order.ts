import { Customer } from "./customer";
import { ProductInOrder } from "./productInOrder";
import { Status } from "./status";

export class Order{
    id = 0;
    date: Date = new Date;
    client: Customer = new Customer;
    status: Status = new Status;
    totalCost = 0;
    comment = "";
    productsInOrder: ProductInOrder[] = [];

    
}
