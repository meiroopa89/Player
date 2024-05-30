import { Component } from '@angular/core';
import { Book } from '../models/book.model';
import { Router } from '@angular/router';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent {
  newBook: Book = {
    bookId: 0,
    title: '',
    author: '',
    genre: '',
    price: 0,
    isbn: ''
  };

  formSubmitted = false;

  constructor(private bookService: BookService, private router: Router) { }

  addBook(): void {
    this.formSubmitted = true;
    if (this.isFormValid()) {
      this.bookService.addBook(this.newBook).subscribe(() => {
        console.log('Book added successfully!');
        this.router.navigate(['/viewBooks']);
      });
    }
  }
  
  isFieldInvalid(fieldName: string): boolean {
    const fieldValue = this.newBook[fieldName as keyof Book];
    return !fieldValue && this.formSubmitted;
  }

  isFormValid(): boolean {
    return !this.isFieldInvalid('title') && !this.isFieldInvalid('author') &&
      !this.isFieldInvalid('genre') && !this.isFieldInvalid('price') &&
      !this.isFieldInvalid('isbn');
  }
}
