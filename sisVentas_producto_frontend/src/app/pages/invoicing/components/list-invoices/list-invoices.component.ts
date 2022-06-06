import { Component, OnInit } from '@angular/core';
import { InvoiceMaster } from '../../models/invoice-master';
import { CreateInvoiceService } from '../../services/create-invoice.service';

@Component({
  selector: 'app-list-invoices',
  templateUrl: './list-invoices.component.html',
  styleUrls: ['./list-invoices.component.scss']
})
export class ListInvoicesComponent implements OnInit{

    invoices: InvoiceMaster[] = [];

    constructor(private _createInvoiceService: CreateInvoiceService) {}

    ngOnInit(): void {
        this.getInvoices();
    }

    getInvoices() {
        this._createInvoiceService.getInvoices().subscribe(t=>
            {
                debugger;
                this.invoices = Object.assign([],t.invoiceMasters);
            });
            this.invoices
    }

}
