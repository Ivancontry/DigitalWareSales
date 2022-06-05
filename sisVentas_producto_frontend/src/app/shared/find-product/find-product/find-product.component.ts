import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FindProductModel} from "../find-product-model";

@Component({
    selector: 'app-find-product',
    templateUrl: './find-product.component.html',
    styleUrls: ['./find-product.component.scss']
})
export class FindProductComponent implements OnInit {
    @Output() onFoundProduct: EventEmitter<FindProductModel> = new EventEmitter<FindProductModel>();
    request: FindProductRequest = new FindProductRequest();
    submitButtonOptions: any = {
        text: 'Buscar',
        useSubmitBehavior: true
    };

    constructor() {
    }

    ngOnInit(): void {
    }

    FindProduct() {
        const product = new FindProductModel();
        product.code = "CJa-89";
        product.name = "Azucar";
        product.price = 45000;
        product.amount = 150;
        this.onFoundProduct.emit(product);
    }
}

export class FindProductRequest {
    code: string | undefined;
}
