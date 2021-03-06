import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {InvoiceMaster} from '../../models/invoice-master';
import {ListInvoicesService} from '../../services/list-invoices.service';

@Component({
    selector: 'app-list-invoices',
    templateUrl: './list-invoices.component.html',
    styleUrls: ['./list-invoices.component.scss']
})
export class ListInvoicesComponent implements OnInit {

    invoices: InvoiceMaster[] = [];

    constructor(private _listInvoicesService: ListInvoicesService, private router: Router) {

    }

    ngOnInit(): void {
        this.getInvoices();
    }

    getInvoices() {
        this._listInvoicesService.getInvoices().subscribe(t => {
            this.invoices = Object.assign([], t.invoiceMasters);
        });
    }

    CreateInvoice() {
        this.router.navigate(['invoicing/create'])
    }

    seeDetail(invoice: InvoiceMaster): void {
        this.router.navigate([`invoicing/${invoice.id}/detail`])
    }



    cancelInvoice(invoice: InvoiceMaster){
        this._listInvoicesService.cancelInvoice(invoice.id, new Date()).subscribe(result => {
            if (!result) return;
            alert(result.message);
            this.getInvoices();
        });
    }
}
