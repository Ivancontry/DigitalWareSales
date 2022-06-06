import {Component, OnInit} from '@angular/core';
import {FindClientModel} from "../../../../shared/find-client/find-client-model";
import {FindProductModel} from "../../../../shared/find-product/find-product-model";
import {InvoiceDetail} from '../../models/invoice-detail';

@Component({
    selector: 'app-create-invoice',
    templateUrl: './create-invoice.component.html',
    styleUrls: ['./create-invoice.component.scss']
})
export class CreateInvoiceComponent implements OnInit {
    client: FindClientModel = new FindClientModel();
    product: FindProductModel = new FindProductModel();
    details: InvoiceDetail[] = [];
    submitButtonOptions: any = {
        text: 'Agregar',
        onClick: this.AddProduct.bind(this)
    };


    constructor() {
    }

    ngOnInit(): void {
    }

    SetClient(client: FindClientModel) {
        this.client = client || new FindClientModel();
    }

    SetProduct(product: FindProductModel) {
        this.product = product;
        this.product.amountToBeAdded =  0;
    }

    private AddProduct() {
        if (!this.product) return;
        const sameDetail = this.details.find(t => t.productName == this.product.name);
        if (sameDetail) {
            sameDetail.amount = Number(this.product.amountToBeAdded);
            sameDetail.total = (this.product.price || 0) * (sameDetail.amount || 0)
            return;
        }
        const detail: InvoiceDetail = Object.assign({
            productName: this.product.name,
            total: (this.product.price || 0) * (this.product.amountToBeAdded || 0)
        }, this.product)
        detail.amount = Number(this.product.amountToBeAdded);
        this.details.push(detail);
    }
}

export class ProductToBeAdded {
    code: string | undefined;
    name: string | undefined;
    price: number | undefined;
    amount: number | undefined;
    amountToBeAdded: number | undefined;
}
