import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FindClientComponent } from './find-client/find-client.component';
import {DxFormModule, DxSelectBoxModule} from "devextreme-angular";



@NgModule({
    declarations: [
        FindClientComponent
    ],
    exports: [
        FindClientComponent
    ],
    imports: [
        CommonModule,
        DxFormModule,
        DxSelectBoxModule
    ]
})
export class FindClientModule { }
