import { Client } from "./Client";
import { InvoiceDetail } from "./invoice-detail";

export class InvoiceMaster {
    id : number | undefined;
    client : Client | undefined;
    dateCancel: Date | undefined;
    createdAt: Date | undefined;
    total:number | undefined;
    clientId: number | undefined;
    status: string | undefined;
    details: InvoiceDetail[] = [];
}



