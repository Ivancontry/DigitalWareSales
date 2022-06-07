import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from 'src/environments/environment';
import {FindClientModel} from "../find-client/find-client-model";

@Injectable({
    providedIn: 'root'
})
export class ClientService {

    constructor(public httpClient: HttpClient) {
    }

    getClientForIdentification(identification?: string): Observable<any> {
        return this.httpClient.get<any>(`${environment.baseUrl}client/` + identification);
    }
    getClients(): Observable<{clients:FindClientModel[],}> {
        return this.httpClient.get<{clients:FindClientModel[]}>(`${environment.baseUrl}client/`);
    }
}
