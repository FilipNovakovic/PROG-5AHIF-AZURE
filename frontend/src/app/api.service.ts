import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

export interface Book {
  id: number;
  title: string;
  price: number;
}

export interface CreateBookRequest {
  title: string;
  price: number;
}

@Injectable({ providedIn: 'root' })
export class ApiService {
  constructor(private http: HttpClient) {}

  getBooks() {
    return this.http.get<Book[]>(`${environment.apiBaseUrl}/books`);
  }

  addBook(req: CreateBookRequest) {
    return this.http.post<Book>(`${environment.apiBaseUrl}/books`, req);
  }
}
