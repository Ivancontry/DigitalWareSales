import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CreateInvoiceComponent} from './components/create-invoice/create-invoice.component';
import {FindProductModule} from "../../shared/find-product/find-product.module";
import {FindClientModule} from "../../shared/find-client/find-client.module";
import {RouterModule} from "@angular/router";
import {DxiItemModule} from "devextreme-angular/ui/nested";
import {DxButtonModule, DxDataGridModule, DxFormModule, DxPopupModule} from "devextreme-angular";
import { ListInvoicesComponent } from './components/list-invoices/list-invoices.component';
import { DetailInvoiceComponent } from './components/detail-invoice/detail-invoice.component';

const routes = [
    {
        path: '',
        component:ListInvoicesComponent
    },
    {
        path: 'create',
        component:CreateInvoiceComponent
    },
    {
        path: ':invoiceId/detail',
        component:DetailInvoiceComponent
    }
]

@NgModule({
    declarations: [
        CreateInvoiceComponent,
        ListInvoicesComponent,
        DetailInvoiceComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        FindProductModule,
        FindClientModule,
        DxiItemModule,
        DxFormModule,
        DxDataGridModule,
        DxButtonModule,
        DxPopupModule
    ]
})
export class InvoicingModule {
}
