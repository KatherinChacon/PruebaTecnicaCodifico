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

@Component({
  selector: 'app-dialog',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatDialogModule, MatTableModule],
  templateUrl: './dialogViewOrders.component.html',
  styleUrl: './dialogViewOrders.component.css'
})

export class DialogComponent implements OnInit {
  orders: MatTableDataSource<any> = new MatTableDataSource();
  displayedColumns: string[] = ['orderid', 'requireddate', 'shipaddress', 'shipcity', 'shipname', 'shippeddate'];

  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private service: ClientOrdersService
  ) { }

  ngOnInit(): void {
    if (this.data?.idCliente) {
      this.service.obtenerOrdenes(this.data.idCliente).subscribe({
        next: (res) => {
          this.orders.data = res;
        },
        error: (err) => console.error(err)
      });
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}