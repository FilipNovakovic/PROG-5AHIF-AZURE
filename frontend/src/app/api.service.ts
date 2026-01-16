import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable({ providedIn: 'root' })
export class ApiService {
  constructor(private http: HttpClient) {}

  hello() {
    return this.http.get(`${environment.apiBaseUrl}/`, { responseType: 'text' });
  }

  getProducts() {
    return this.http.get<any[]>(`${environment.apiBaseUrl}/products`);
  }
}
