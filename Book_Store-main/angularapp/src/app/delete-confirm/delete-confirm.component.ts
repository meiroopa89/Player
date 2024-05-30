import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../models/book.model'; // Adjusted model name
import { BookService } from '../services/book.service'; // Adjusted service name

@Component({
  selector: 'app-delete-confirm', // Component selector
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  bookId: number;
  book: Book = {} as Book; // Initialize book property with an empty object

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private bookService: BookService // Adjusted service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.bookId = +params['id']; // Adjust parameter name
      this.bookService.getBook(this.bookId).subscribe(
        (book: Book) => { // Adjust type casting
          this.book = book;
        },
        error => {
          console.error('Error fetching book:', error);
        }
      );
    });
  }

  confirmDelete(bookId: number): void { // Adjust method signature
    this.bookService.deleteBook(bookId).subscribe(
      () => {
        console.log('Book deleted successfully.');
        this.router.navigate(['/viewBooks']); // Adjust the route
      },
      (error) => {
        console.error('Error deleting book:', error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/viewBooks']); // Adjust the route
  }
}
