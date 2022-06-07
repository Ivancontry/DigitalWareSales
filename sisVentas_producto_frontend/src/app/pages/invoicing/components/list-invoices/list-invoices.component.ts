import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InvoiceMaster } from '../../models/invoice-master';
import { CreateInvoiceService } from '../../services/create-invoice.service';

@Component({
  selector: 'app-list-invoices',
  templateUrl: './list-invoices.component.html',
  styleUrls: ['./list-invoices.component.scss']
})
export class ListInvoicesComponent implements OnInit{

    invoices: InvoiceMaster[] = [];

    constructor(private _createInvoiceService: CreateInvoiceService,private router: Router) {}

    ngOnInit(): void {
        this.getInvoices();
    }

    getInvoices() {
        this._createInvoiceService.getInvoices().subscribe(t=>
            {
                this.invoices = Object.assign([],t.invoiceMasters);
            });
    }

    CreateInvoice(){
        this.router.navigate(['invoicing/create'])
    }
    deleteRecords():void{
        this.router.navigate(['invoicing/detail'])
    }
}
