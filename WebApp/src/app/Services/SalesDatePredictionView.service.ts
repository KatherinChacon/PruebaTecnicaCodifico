import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../Settings/appsettings';
import { ClientPrediction } from '../Models/ClientPrediction';

@Injectable({
  providedIn: 'root'
})
export class ClientPredictionService {
  
  private http = inject(HttpClient);
  private apiUrl:string = appsettings.apiUrl + "Customers/GetListaDatePrediction";

  constructor() { }

  lista(){
      return this.http.get<ClientPrediction[]>(this.apiUrl);
    }
}
