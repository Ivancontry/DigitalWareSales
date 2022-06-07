import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FindProductModel } from '../find-product/find-product-model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

    constructor(public httpClient: HttpClient) { }

    getProducts() : Observable<{products:FindProductModel[],}>
    {
      return this.httpClient.get<{products:FindProductModel[]}>(`${environment.baseUrl}category/product`);
    }
}
