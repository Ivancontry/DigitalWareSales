import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CreateInvoiceComponent} from './components/create-invoice/create-invoice.component';
import {FindProductModule} from "../../shared/find-product/find-product.module";
import {FindClientModule} from "../../shared/find-client/find-client.module";
import {RouterModule} from "@angular/router";
import {DxiItemModule} from "devextreme-angular/ui/nested";
import {DxDataGridModule, DxFormModule} from "devextreme-angular";

const routes = [
    {
        path: '',
        component:CreateInvoiceComponent
    }
]

@NgModule({
    declarations: [
        CreateInvoiceComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        FindProductModule,
        FindClientModule,
        DxiItemModule,
        DxFormModule,
        DxDataGridModule
    ]
})
export class InvoicingModule {
}
