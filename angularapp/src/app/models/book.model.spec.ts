import { Book } from './book.model'; // Import Book model

describe('Book', () => { // Updated description to 'Book'
  fit('should_create_book_instance', () => { // Updated test description
    const book: Book = { // Updated 'fitness' to 'book'
      bookId: 1, // Adjusted property name
      title: 'The Great Gatsby', // Adjusted property name
      author: 'F. Scott Fitzgerald', // Adjusted property name
      genre: 'Fiction', // Adjusted property name
      price: 10.99, // Adjusted property name
      isbn: '978-0743273565' // Adjusted property name
    };

    // Check if the book object exists
    expect(book).toBeTruthy();

    // Check individual properties of the book
    expect(book.bookId).toBe(1); // Adjusted property name
    expect(book.title).toBe('The Great Gatsby'); // Adjusted property name
    expect(book.author).toBe('F. Scott Fitzgerald'); // Adjusted property name
    expect(book.genre).toBe('Fiction'); // Adjusted property name
    expect(book.price).toBe(10.99); // Adjusted property name
    expect(book.isbn).toBe('978-0743273565'); // Adjusted property name
  });
});
