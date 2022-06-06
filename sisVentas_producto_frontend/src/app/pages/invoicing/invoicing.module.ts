import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CreateInvoiceComponent} from './components/create-invoice/create-invoice.component';
import {FindProductModule} from "../../shared/find-product/find-product.module";
import {FindClientModule} from "../../shared/find-client/find-client.module";
import {RouterModule} from "@angular/router";
import {DxiItemModule} from "devextreme-angular/ui/nested";
import {DxButtonModule, DxDataGridModule, DxFormModule} from "devextreme-angular";
import { ListInvoicesComponent } from './components/list-invoices/list-invoices.component';

const routes = [
    {
        path: '',
        component:ListInvoicesComponent
    },
    {
        path: 'create',
        component:CreateInvoiceComponent
    }
]

@NgModule({
    declarations: [
        CreateInvoiceComponent,
        ListInvoicesComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        FindProductModule,
        FindClientModule,
        DxiItemModule,
        DxFormModule,
        DxDataGridModule,
        DxButtonModule
    ]
})
export class InvoicingModule {
}
