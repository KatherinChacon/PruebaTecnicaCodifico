import { Orders } from "./Ordes";
import { OrderDetails } from "./OrdersDetails";

export interface NewClientOrders{
    orden: Orders,
    detalle: OrderDetails;
}
