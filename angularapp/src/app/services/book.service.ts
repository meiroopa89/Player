import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book.model'; // Import Book model

@Injectable({
  providedIn: 'root'
})
export class BookService { // Updated service name
  private apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addBook(book: Book): Observable<Book> { // Adjusted method name and parameter
    return this.http.post<Book>(`${this.apiUrl}/api/Books`, book); // Adjusted endpoint and parameter
  }

  getBooks(): Observable<Book[]> { // Adjusted method name
    return this.http.get<Book[]>(`${this.apiUrl}/api/Books`); // Adjusted endpoint
  }

  deleteBook(bookId: number): Observable<void> { // Adjusted method name and parameter
    const url = `${this.apiUrl}/api/Books/${bookId}`; // Adjusted the URL to match your API endpoint
    return this.http.delete<void>(url); // Adjusted endpoint and parameter
  }

  getBook(bookId: number): Observable<Book> { // Adjusted method name and return type
    const url = `${this.apiUrl}/api/Books/${bookId}`; // Adjusted the URL to match your API endpoint
    return this.http.get<Book>(url); // Adjusted endpoint and return type
  }
}
