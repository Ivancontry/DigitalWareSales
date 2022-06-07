import {Component, OnInit} from '@angular/core';
import {InvoiceMaster} from '../../models/invoice-master';
import {CreateInvoiceService} from '../../services/create-invoice.service';
import {ActivatedRoute} from "@angular/router";

@Component({
    selector: 'tests-detail-invoice',
    templateUrl: './detail-invoice.component.html',
    styleUrls: ['./detail-invoice.component.scss']
})
export class DetailInvoiceComponent implements OnInit {
    invoiceMaster: InvoiceMaster = new InvoiceMaster();
    invoiceId: number = 0;

    constructor(private _createInvoiceService: CreateInvoiceService, _activatedRoute: ActivatedRoute) {
        this.invoiceId = _activatedRoute.snapshot.params.invoiceId;
    }

    ngOnInit(): void {
        this.getInvoice()
    }

    getInvoice() {
        this._createInvoiceService.getInvoice(this.invoiceId).subscribe(t => {
            this.invoiceMaster = Object.assign({} as InvoiceMaster, t.invoiceMaster);
        });
    }

}
