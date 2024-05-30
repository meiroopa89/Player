import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../services/book.service'; // Adjusted service name
import { Book } from '../models/book.model'; // Adjusted model name

@Component({
  selector: 'app-book-list', // Adjusted selector
  templateUrl: './book-list.component.html', // Adjusted template URL
  styleUrls: ['./book-list.component.css'] // Adjusted style URL
})
export class BookListComponent implements OnInit {
  books: Book[] = []; // Adjusted property name

  constructor(private bookService: BookService, private router: Router) { } // Adjusted service name

  ngOnInit(): void {
    this.loadBooks(); // Adjusted method name
  }

  loadBooks(): void {
    this.bookService.getBooks().subscribe(books => { // Adjusted method name
      this.books = books;
      console.log(this.books);
    });
  }

  deleteBook(bookId: number): void { // Adjusted method name and parameter
    // Navigate to confirm delete page with the book ID as a parameter
    this.router.navigate(['/confirmDelete', bookId]);
  }
}
