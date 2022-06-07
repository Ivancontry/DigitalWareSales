import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {ClientService} from '../../services/client.service';
import {FindClientModel} from "../find-client-model";
import {Client} from "../../../pages/invoicing/models/Client";

@Component({
    selector: 'app-find-client',
    templateUrl: './find-client.component.html',
    styleUrls: ['./find-client.component.scss']
})
export class FindClientComponent implements OnInit {
    @Output() onFoundClient: EventEmitter<FindClientModel> = new EventEmitter<FindClientModel>();
    public request: FindClientRequest = new FindClientRequest();
    public clients: FindClientModel[] = [];

    constructor(private clientService: ClientService) {
    }

    ngOnInit(): void {
        this.getClients();
    }

    private getClients() {
        this.clientService.getClients().subscribe(result => {
            this.clients = result.clients;
        })
    }

    findClient(client: FindClientModel) {
        this.onFoundClient.emit(client);
    }
}

export class FindClientRequest {
    constructor(public identification?: string) {
    }
}
