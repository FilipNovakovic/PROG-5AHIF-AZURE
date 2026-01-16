import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService, Book } from './api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  imports: [CommonModule, FormsModule],
})
export class App {
  message = '';
  books: Book[] = [];

  // Form fields
  title = '';
  price: number | null = 10;

  isLoading = false;

  constructor(private api: ApiService) {}

  loadBooks() {
    this.isLoading = true;
    this.message = '';

    this.api.getBooks().subscribe({
      next: (b) => {
        this.books = b;
        this.isLoading = false;
      },
      error: (e) => {
        this.message = 'Error loading books: ' + (e?.message ?? e);
        this.isLoading = false;
      },
    });
  }

  addBook() {
    const t = this.title.trim();
    const p = this.price ?? 0;

    if (!t) {
      this.message = 'Title is required';
      return;
    }

    this.isLoading = true;
    this.message = '';

    this.api.addBook({ title: t, price: p }).subscribe({
      next: () => {
        this.title = '';
        this.price = 10;
        this.loadBooks();
      },
      error: (e) => {
        // Backend liefert 400 mit Text -> den zeigen wir mit an
        const backendMsg =
          e?.error && typeof e.error === 'string' ? ` (${e.error})` : '';
        this.message = 'Error adding book: ' + (e?.message ?? e) + backendMsg;
        this.isLoading = false;
      },
    });
  }
}
