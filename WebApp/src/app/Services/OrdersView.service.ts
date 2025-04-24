import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { ClientOrders } from '../Models/ClientOrders';
import { NewClientOrders } from '../Models/NewClientOrders';
import { ResponseAPI } from '../Models/ResponseAPI';

@Injectable({
  providedIn: 'root'
})

export class ClientOrdersService {
  private http = inject(HttpClient);
  private apiUrl:string = appsettings.apiUrl + "Orders/ListaGetClientOrdersID";
  private apiUrlCrear:string = appsettings.apiUrl + "CreateOrders/CrearOrder"
  
  constructor() { }


  lista(){
    return this.http.get<ClientOrders[]>(this.apiUrl);
  }

  obtenerOrdenes(id:number){
    return this.http.get<ClientOrders[]>(`${this.apiUrl}/${id}`);
  }
  
  crearOrden(objeto:NewClientOrders){
    return this.http.post<ResponseAPI>(this.apiUrlCrear, objeto);
  }
}
