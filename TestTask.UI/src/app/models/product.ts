import { Category } from "./category";

export class Product{
    productId?: number;
    name = "";
    category: Category = new Category;
    price = 0;
    quantity = 0;
    date: Date = new Date;
    description = ""; 
}