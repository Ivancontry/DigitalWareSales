import { ProductService } from './../../services/product.service';
import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import { Product } from 'src/app/pages/invoicing/models/product';
import { FindProductModel } from '../find-product-model';

@Component({
    selector: 'app-find-product',
    templateUrl: './find-product.component.html',
    styleUrls: ['./find-product.component.scss']
})
export class FindProductComponent implements OnInit {
    @Output() onFoundProduct: EventEmitter<FindProductModel> = new EventEmitter<FindProductModel>();
    public products: FindProductModel[] = [];
    submitButtonOptions: any = {
        text: 'Buscar',
        useSubmitBehavior: true
    };

    constructor(private productService:ProductService) {
    }

    ngOnInit(): void
    {
        this.getProducts();
    }

    findProduct(product: FindProductModel) {

        this.onFoundProduct.emit(product);
    }



    private getProducts() {
        this.productService.getProducts().subscribe(result => {
            this.products =result.products;
        })
    }


}

export class FindProductRequest {
    code: string | undefined;
}
