import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { Book } from '../models/book.model';
import { BookService } from './book.service';

describe('BookService', () => {
  let service: BookService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [BookService],
    });
    service = TestBed.inject(BookService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('BookService_should be created', () => {
    expect(service).toBeTruthy();
  });

  fit('BookService_should have getBooks method', () => {
    expect(service['getBooks']).toBeTruthy();
  });

  fit('BookService_should have getBook method', () => {
    expect(service['getBook']).toBeTruthy();
  });

  fit('BookService_should have addBook method', () => {
    expect(service['addBook']).toBeTruthy();
  });

  fit('BookService_should add a book and return it', () => {
    const mockBook: Book = {
      bookId: 1,
      title: 'Test book',
      author: 'Test author',
      category: 'Test category',
      publicationYear: 2022,
      publisher: 'Test publisher',
      price: 100,
      numberOfPages: 200
    };

    service.addBook(mockBook).subscribe((book) => {
      expect(book).toEqual(mockBook);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/book`);
    expect(req.request.method).toBe('POST');
    req.flush(mockBook);
  });

  
  fit('BookService_should get books', () => {
    const mockBooks: Book[] = [
      {
        bookId: 1,
        title: 'Test book 1',
        author: 'Test author',
        category: 'Test category',
        publicationYear: 2022,
        publisher: 'Test publisher',
        price: 100,
        numberOfPages: 200
      }
    ];

    service.getBooks().subscribe((books) => {
      expect(books).toEqual(mockBooks);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/book`);
    expect(req.request.method).toBe('GET');
    req.flush(mockBooks);
  });

});
