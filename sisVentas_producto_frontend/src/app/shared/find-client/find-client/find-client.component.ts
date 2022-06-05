import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FindClientModel} from "../find-client-model";

@Component({
    selector: 'app-find-client',
    templateUrl: './find-client.component.html',
    styleUrls: ['./find-client.component.scss']
})
export class FindClientComponent implements OnInit {
    @Output() onFoundClient: EventEmitter<FindClientModel> = new EventEmitter<FindClientModel>();
    public request: FindClientRequest = new FindClientRequest();
    submitButtonOptions = {
        text: 'Buscar',
        useSubmitBehavior: true
    };

    constructor() {
    }

    ngOnInit(): void {
    }

    FindClient() {
        const client = new FindClientModel();
        client.identification = "1065840833";
        client.phone = "3218599874";
        client.email = "duvanguia@gmail.com";
        client.name = "Duvan Guia";
        this.onFoundClient.emit(client);
    }
}

export class FindClientRequest {
    constructor(public identification?: string) {
    }
}
