import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ListInvoicesService {

  constructor(private _httpClient: HttpClient) { }

  getInvoices(): Observable<any>{
    return this._httpClient.get<any>(`${environment.baseUrl}invoice`);
}
}
