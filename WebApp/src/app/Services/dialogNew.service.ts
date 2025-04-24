import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from '../Pages/dialogNewOrders/dialogNewOrders.component';


@Injectable({
  providedIn: 'root'
})
export class DialogNewService {


  constructor(public dialog: MatDialog) {}
  
  openDialogNewM(idCliente: number, customerName: string): void {
      const dialogRef = this.dialog.open(DialogComponent, {
        data: { idCliente, customerName },  
        width: '70vw'
      });
  
      dialogRef.afterClosed().subscribe(result => {
        console.log('El modal se cerró');
      });
    }
}
