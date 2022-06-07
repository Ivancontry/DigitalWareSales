import { Component, OnInit } from '@angular/core';
import { InvoiceMaster } from '../../models/invoice-master';
import { CreateInvoiceService } from '../../services/create-invoice.service';

@Component({
  selector: 'tests-detail-invoice',
  templateUrl: './detail-invoice.component.html',
  styleUrls: ['./detail-invoice.component.scss']
})
export class DetailInvoiceComponent implements OnInit {
  invoiceMaster: InvoiceMaster = new InvoiceMaster();
  constructor(private _createInvoiceService: CreateInvoiceService) { }

  ngOnInit(): void {
        this.getInvoice()
    }

    getInvoice() {
        this._createInvoiceService.getInvoices().subscribe(t=>
            {
                this.invoiceMaster = Object.assign(this.invoiceMaster,t.invoiceMaster);
            });
    }

}
