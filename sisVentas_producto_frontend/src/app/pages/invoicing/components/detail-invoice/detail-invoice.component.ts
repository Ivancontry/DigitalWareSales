import {Component, OnInit} from '@angular/core';
import {InvoiceMaster} from '../../models/invoice-master';
import {ActivatedRoute} from "@angular/router";
import { DetailInvoiceService } from '../../services/detail-invoice.service';

@Component({
    selector: 'tests-detail-invoice',
    templateUrl: './detail-invoice.component.html',
    styleUrls: ['./detail-invoice.component.scss']
})
export class DetailInvoiceComponent implements OnInit {
    invoiceMaster: InvoiceMaster = new InvoiceMaster();
    invoiceId: number = 0;

    constructor(private _detailInvoiceService: DetailInvoiceService, _activatedRoute: ActivatedRoute) {
        this.invoiceId = _activatedRoute.snapshot.params.invoiceId;
    }

    ngOnInit(): void {
        this.getInvoice()
    }

    getInvoice() {
        this._detailInvoiceService.getInvoice(this.invoiceId).subscribe(t => {
            this.invoiceMaster = Object.assign({} as InvoiceMaster, t.invoiceMaster);
        });
    }

}
