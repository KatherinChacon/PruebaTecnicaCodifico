import { Routes } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { ViewOrdersComponent } from './Pages/view-orders/view-orders.component';

export const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'Home', component:HomeComponent},
    {path:'OrdersView/:id', component:ViewOrdersComponent},
];
