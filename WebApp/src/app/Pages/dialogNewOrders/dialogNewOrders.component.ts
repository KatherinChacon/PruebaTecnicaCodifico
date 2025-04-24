import { Component, Inject } from '@angular/core';
import { ChangeDetectionStrategy, inject, model, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { OnInit } from '@angular/core';
import { ClientOrdersService } from '../../Services/OrdersView.service';
import { MatTableModule } from '@angular/material/table';
import { NewClientOrders } from '../../Models/NewClientOrders';
import { Orders } from '../../Models/Ordes';
import { OrderDetails } from '../../Models/OrdersDetails';

@Component({
  selector: 'app-dialog',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatDialogModule, MatTableModule],
  templateUrl: './dialogNewOrders.component.html',
  styleUrl: './dialogNewOrders.component.css'
})

export class DialogComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private service: ClientOrdersService
  ) { }

  ngOnInit(): void {
    
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  nuevaOrden: Orders = {
    empid: this.data?.idCliente ?? 0,
    shipperid: 0,
    shipname: '',
    shipaddress : '',
    shipcity : '',
    orderdate : '',
    requireddate : '',
    shippeddate : '',
    freight : 0,
    Shipcountry : ''
  };

  nuevoDetalle: OrderDetails = {
    productid: 0,
    unitprice: 0,
    qty: 0,
    discount: 0
  };

  guardar() {
    const nuevaOrdenCompleta: NewClientOrders = {
      orden: this.nuevaOrden,
      detalle: this.nuevoDetalle
    };
  
    this.service.crearOrden(nuevaOrdenCompleta).subscribe({
      next: (res) => {
        alert('Orden creada con éxito');
        this.dialogRef.close(true);
      },
      error: (err) => {
        console.error('Error al guardar la orden:', err);
        alert('Error al guardar la orden');
      }
    });
  }
}