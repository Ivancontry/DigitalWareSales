import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import { ClientService } from '../../services/client.service';
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

    constructor(private clientService: ClientService) {
    }

    ngOnInit(): void {
    }

    findClient() {
        var findClientRequest = this.request;
        var client = new FindClientModel();
        this.clientService.getClientForIdentification(findClientRequest.identification).subscribe(t=>
            {
                Object.assign(client,t.client);
            });
        this.onFoundClient.emit(client);
    }
}

export class FindClientRequest {
    constructor(public identification?: string) {
    }
}
