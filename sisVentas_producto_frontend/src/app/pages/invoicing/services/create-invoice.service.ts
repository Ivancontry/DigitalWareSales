import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from 'rxjs';
import {environment} from "../../../../environments/environment";
import { InvoiceMaster } from '../models/invoice-master';

@Injectable({
    providedIn: 'root'
})
export class CreateInvoiceService {

    constructor(private _httpClient: HttpClient) {
    }

    createInvoice(request: CreateInvoiceRequest): Observable<{ message: string }> {
        return this._httpClient.post<{ message: string }>(`${environment.baseUrl}invoice`, request);
    }

    getInvoices(): Observable<any>{
        return this._httpClient.get<any>(`${environment.baseUrl}invoice`);
    }
    getInvoice(id:number): Observable<InvoiceMaster>{
        return this._httpClient.get<any>(`${environment.baseUrl}invoice/${id}`);
    }
}

class CreateInvoiceProductRequest {
    productId: number | undefined;
    amount: number | undefined;
}

export class CreateInvoiceRequest {
    clientId: number | undefined;
    date: Date | undefined;
    products: CreateInvoiceProductRequest[] | undefined;
}
