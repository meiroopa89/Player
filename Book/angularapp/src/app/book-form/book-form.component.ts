// src/app/book-form/book-form.component.ts
import { Component } from '@angular/core';
import { Book } from '../models/book.model';
import { BookService } from '../services/book.service';


@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent {
  newBook: Book = { bookId: 0, title: '', author: '', category: '', publicationYear: 0, publisher: '', price: 0, numberOfPages: 0 };

  constructor(private bookService: BookService) { }

  addBook(): void {
    this.bookService.addBook(this.newBook).subscribe(() => {
      console.log('Book added successfully!');
    });
  }
}
