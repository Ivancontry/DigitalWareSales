import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class AppInfoService {
  constructor() {}

  public get title() {
    return 'SisVentasProductos';
  }

  public get currentYear() {
    return new Date().getFullYear();
  }

}
