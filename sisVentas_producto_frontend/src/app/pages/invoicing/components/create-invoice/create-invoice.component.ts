import {Component, OnInit} from '@angular/core';
import {FindClientModel} from "../../../../shared/find-client/find-client-model";
import {FindProductModel} from "../../../../shared/find-product/find-product-model";
import {InvoiceDetail} from '../../models/invoice-detail';
import {CreateInvoiceRequest, CreateInvoiceService} from "../../services/create-invoice.service";
import CustomStore from "devextreme/data/custom_store";

@Component({
    selector: 'app-create-invoice',
    templateUrl: './create-invoice.component.html',
    styleUrls: ['./create-invoice.component.scss']
})
export class CreateInvoiceComponent implements OnInit {
    client: FindClientModel = new FindClientModel();
    product: FindProductModel = new FindProductModel();
    details: InvoiceDetail[] = [];
    dataSource: any;
    submitButtonOptions: any = {
        text: 'Agregar',
        onClick: this.AddProduct.bind(this)
    };

    constructor(private _createInvoiceService: CreateInvoiceService) {
    }

    ngOnInit(): void {
        this.dataSource = new CustomStore({
            key:"productId",
            load:options => this.details,
            remove: key => this.RemoveProduct(key)
        })
    }

    SetClient(client: FindClientModel) {
        this.client = client || new FindClientModel();
    }

    SetProduct(product: FindProductModel) {
        this.product = product;
        this.product.amountToBeAdded = 0;
    }

    private AddProduct() {
        if (!this.product) return;
        if (!this.validateAmount()) return;
        const sameDetail = this.details.find(t => t.productName == this.product.name);
        if (sameDetail) {
            sameDetail.amount = Number(this.product.amountToBeAdded);
            sameDetail.total = (this.product.price || 0) * (sameDetail.amount || 0)
            return;
        }
        const detail: InvoiceDetail = Object.assign({
            productId: this.product.id,
            productName: this.product.name,
            total: (this.product.price || 0) * (this.product.amountToBeAdded || 0)
        }, this.product)
        detail.amount = Number(this.product.amountToBeAdded);
        this.details.push(detail);
    }

    CreateInvoice() {
        if (!this.details || this.details.length == 0) return;
        const request: CreateInvoiceRequest = {
            clientId: this.client.id,
            date: new Date(),
            products: this.details.map(t => ({productId: t.productId, amount: t.amount}))
        }
        this._createInvoiceService.createInvoice(request).subscribe(result => {
            if (!result) return;
            alert(result.message);
        })
    }

    private RemoveProduct(productId: number) {
        const indexDetail =  this.details.findIndex(t=> t.productId == productId);
        this.details.splice(indexDetail, 1);
        return Promise.resolve(undefined);
    }

    validateAmount() {
        return this.AmountBeNonNegative() && this.AmountBeLessThanStock();
    }

    AmountBeNonNegative() {
        return (this.product?.amountToBeAdded || 0) > 0;
    }
    AmountBeLessThanStock = () =>  (this.product.amountToBeAdded || 0) <= (this.product.amount || 0);
}

export class ProductToBeAdded {
    code: string | undefined;
    name: string | undefined;
    price: number | undefined;
    amount: number | undefined;
    amountToBeAdded: number | undefined;
}
