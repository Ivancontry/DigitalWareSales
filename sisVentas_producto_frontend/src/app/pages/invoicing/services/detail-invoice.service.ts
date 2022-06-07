import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DetailInvoiceService {

  constructor(private _httpClient: HttpClient) { }

  getInvoice(id:number): Observable<any>{
    return this._httpClient.get<any>(`${environment.baseUrl}invoice/${id}`);
}
}
