import { ProductService } from './../../services/product.service';
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

    constructor(private productService:ProductService) {
    }

    ngOnInit(): void {
    }

    findProduct() {
        var findProductRequest = this.request;
        var product = new FindProductModel();
        this.productService.getProductForCode(findProductRequest.code).subscribe(t=>
            {
                Object.assign(product,t.product);
            });
        this.onFoundProduct.emit(product);
    }
}

export class FindProductRequest {
    code: string | undefined;
}
