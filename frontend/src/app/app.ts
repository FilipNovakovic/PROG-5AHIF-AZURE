import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from './api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  imports: [CommonModule],
})
export class App {
  message = '(noch nichts geladen)';
  products: any[] = [];

  constructor(private api: ApiService) {}

  load() {
    this.api.hello().subscribe({
      next: (txt) => (this.message = txt),
      error: (err) => (this.message = 'Error: ' + (err?.message ?? err)),
    });
  }

  loadProducts() {
    this.api.getProducts().subscribe({
      next: (p) => (this.products = p),
      error: (err) => (this.message = 'Error: ' + (err?.message ?? err)),
    });
  }
}
