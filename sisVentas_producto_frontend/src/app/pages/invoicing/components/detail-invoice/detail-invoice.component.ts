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

        this._createInvoiceService.getInvoice(1).subscribe(t=>
            {
                debugger
                this.invoiceMaster = Object.assign({} as InvoiceMaster,t.invoiceMaster);
            });
    }

}
