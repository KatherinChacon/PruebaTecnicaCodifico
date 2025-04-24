import { Component, inject, ViewChild,} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClientOrdersService } from '../../Services/OrdersView.service';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import { ClientOrders } from '../../Models/ClientOrders';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-orders',
  standalone: true,
  imports: [MatCardModule, MatTableModule, MatButtonModule, MatPaginatorModule, MatSortModule],
  templateUrl: './view-orders.component.html',
  styleUrl: './view-orders.component.css'
})
export class ViewOrdersComponent {
  private viewOrderServicio = inject(ClientOrdersService); 
  public displayedColumns : string[] = ['orderid','requireddate', 'shipaddress', 'shipcity', 'shipname', 'shippeddate'];

  public dataSource = new MatTableDataSource<ClientOrders>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort
  
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }  

  constructor(private router:Router, private route: ActivatedRoute){
  }

  customerName: string = ''; 

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    const customerName = this.route.snapshot.queryParamMap.get('customerName');

    if (id) {
      this.obtenerOrdenesCliente(id);
    }

    if (customerName) {
      this.customerName = customerName;   
    }
  }

  obtenerOrdenesCliente(id: number) {
    this.viewOrderServicio.obtenerOrdenes(id).subscribe({
      next: (data) => {
        this.dataSource.data = data;
        console.log("Datos cargados:", data);
      },
      error: (err) => console.error(err)
    });
  }
}
