import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

    constructor(public httpClient: HttpClient) { }

    getProductForCode(code?:string) : Observable<any>
    {
      return this.httpClient.get<any>(`${environment.baseUrl}category/code/`+code+`/product`);
    }
}
