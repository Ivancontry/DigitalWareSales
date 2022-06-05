import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FindProductComponent } from './find-product/find-product.component';
import {DxFormModule} from "devextreme-angular";



@NgModule({
    declarations: [
        FindProductComponent
    ],
    exports: [
        FindProductComponent
    ],
    imports: [
        CommonModule,
        DxFormModule
    ]
})
export class FindProductModule { }
