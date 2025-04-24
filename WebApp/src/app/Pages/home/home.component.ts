import { Component, inject, ViewChild, Inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Router } from '@angular/router';
import { ClientPrediction } from '../../Models/ClientPrediction';
import { ClientPredictionService } from '../../Services/SalesDatePredictionView.service';
import { MatSort, Sort, MatSortModule } from '@angular/material/sort';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule} from '@angular/forms';
import { DialogService } from '../../Services/dialog.service';
import { DialogNewService } from '../../Services/dialogNew.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatCardModule, MatTableModule, MatButtonModule, MatPaginatorModule, MatSortModule, MatInputModule, MatFormFieldModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent {
  private clientPredictionServicio = inject(ClientPredictionService);
  public displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'accion'];

  public dataSource = new MatTableDataSource<ClientPrediction>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  constructor(private router: Router, private readonly dialogService: DialogService, private readonly dialogNewService: DialogNewService) {
    this.obtenerClientPrediction();    
  }

  obtenerClientPrediction() {
    this.clientPredictionServicio.lista().subscribe({
      next: (data) => {
        if (data.length > 0) {
          this.dataSource.data = data;
          console.log(data)
        }
      },
      error: (err) =>
        console.log(err.message)
    })
  }

  filtrar(event: Event){
    const filtro = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filtro.trim().toLowerCase();
  }

  verDetalle(objeto: ClientPrediction) {
    this.router.navigate(['/OrdersView', objeto.idCliente], {
      queryParams: { customerName: objeto.customerName }      
    });
  }

  openDialogView(cliente: ClientPrediction) {
    this.dialogService.openDialog(cliente.idCliente, cliente.customerName);  
  }

  openDialogNew(cliente: ClientPrediction){
    this.dialogNewService.openDialogNewM(cliente.idCliente, cliente.customerName);
  }
}
