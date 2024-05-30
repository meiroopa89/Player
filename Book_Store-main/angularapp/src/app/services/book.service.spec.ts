import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Book } from '../models/book.model'; // Adjusted import
import { BookService } from './book.service'; // Adjusted import

describe('BookService', () => { // Changed description to BookService
  let service: BookService; // Changed service variable name to BookService
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [BookService], // Changed service provider to BookService
    });
    service = TestBed.inject(BookService); // Changed service variable assignment to BookService
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('BookService_should_be_created', () => { // Changed fit to it and updated test description
    expect(service).toBeTruthy();
  });

  fit('BookService_should_add_a_Book_and_return_it', () => { // Changed fit to it and updated test description
    const mockBook: Book = {
      bookId: 1,
      title: 'The Great Gatsby',
      author: 'F. Scott Fitzgerald',
      genre: 'Fiction',
      price: 10.99,
      isbn: '978-0743273565'
    };

    service.addBook(mockBook).subscribe((book) => { // Changed addFitnessClass to addBook and adjusted callback parameter
      expect(book).toEqual(mockBook);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Books`); // Adjusted API endpoint
    expect(req.request.method).toBe('POST');
    req.flush(mockBook);
  });

  fit('BookService_should_get_Books', () => { // Changed fit to it and updated test description
    const mockBooks: Book[] = [
      {
        bookId: 1,
        title: 'The Great Gatsby',
        author: 'F. Scott Fitzgerald',
        genre: 'Fiction',
        price: 10.99,
        isbn: '978-0743273565'
      }
    ];

    service.getBooks().subscribe((books) => { // Changed getFitnessClasses to getBooks and adjusted callback parameter
      expect(books).toEqual(mockBooks);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Books`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockBooks);
  });

  fit('BookService_should_delete_a_Book', () => { // Changed fit to it and updated test description
    const bookId = 100;

    service.deleteBook(bookId).subscribe(() => {
      expect().nothing();
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Books/${bookId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });

  fit('BookService_should_get_a_Book_by_id', () => { // Changed fit to it and updated test description
    const bookId = 100;
    const mockBook: Book = {
      bookId: bookId,
      title: 'The Great Gatsby',
      author: 'F. Scott Fitzgerald',
      genre: 'Fiction',
      price: 10.99,
      isbn: '978-0743273565'
    };

    service.getBook(bookId).subscribe((book) => { // Changed getFitnessClass to getBook and adjusted callback parameter
      expect(book).toEqual(mockBook);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Books/${bookId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockBook);
  });
});
