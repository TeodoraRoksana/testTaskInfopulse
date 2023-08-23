
import { Product } from "./product";
import { ProductSize } from "./productSize";

export class ProductInOrder{
    productInOrderId?: number;
    product: Product = new Product;
    orderId = 0;
    orderQuantity = 0;
    productSize: ProductSize = new ProductSize;
}