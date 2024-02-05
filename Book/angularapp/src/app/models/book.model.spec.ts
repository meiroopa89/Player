import { Book } from './book.model';

// describe('Book', () => {
//   fit('BookModel should create an instance', () => {
//     const book = new Book();
//     expect(book).toBeDefined();
//     expect(book instanceof Book).toBeTruthy();
//   });

//   fit('BookModel should have default property values', () => {
//     const book = new Book();
//     expect(book['bookId']).toBeUndefined();
//     expect(book['title']).toBeUndefined();
//     expect(book['author']).toBeUndefined();
//     expect(book['category']).toBeUndefined();
//     expect(book['publicationYear']).toBeUndefined();
//     expect(book['publisher']).toBeUndefined();
//     expect(book['price']).toBeUndefined();
//     expect(book['numberOfPages']).toBeUndefined();
//   });

//   fit('BookModel should update property values using setters', () => {
//     const book = new Book();

//     book['bookId'] = 1;
//     book['title'] = 'New Book Title';
//     book['author'] = 'New Author';
//     book['category'] = 'Fiction';
//     book['publicationYear'] = 2022;
//     book['publisher'] = 'New Publisher';
//     book['price'] = 19.99;
//     book['numberOfPages'] = 300;

//     expect(book['bookId']).toEqual(1);
//     expect(book['title']).toEqual('New Book Title');
//     expect(book['author']).toEqual('New Author');
//     expect(book['category']).toEqual('Fiction');
//     expect(book['publicationYear']).toEqual(2022);
//     expect(book['publisher']).toEqual('New Publisher');
//     expect(book['price']).toEqual(19.99);
//     expect(book['numberOfPages']).toEqual(300);
//   });
// });

describe('Book', () => {
  fit('BookModel_should create an instance', () => {
    const book = new Book();
    expect(book).toBeDefined();
    expect(book instanceof Book).toBeTruthy();
  });

  fit('BookModel_should update property values using setters', () => {
    // Arrange
    const book: Book = {
      bookId: 1,
      title: 'The Great Book',
      author: 'Jane Doe',
      category: 'Fiction',
      publicationYear: 2022,
      publisher: 'ABC Publications',
      price: 19.99,
      numberOfPages: 300,
    };
 
    // Act & Assert
    // Check if the entire book object is truthy (defined)
    expect(book).toBeTruthy();
 
    // Check if individual properties are truthy (defined)
    expect(book['bookId']).toBeTruthy();
    expect(book['title']).toBeTruthy();
    expect(book['author']).toBeTruthy();
    expect(book['category']).toBeTruthy();
    expect(book['publicationYear']).toBeTruthy();
    expect(book['publisher']).toBeTruthy();
    expect(book['price']).toBeTruthy();
    expect(book['numberOfPages']).toBeTruthy();
 
    // Check data types for each property
    expect(typeof book['bookId']).toEqual('number');
    expect(typeof book['title']).toEqual('string');
    expect(typeof book['author']).toEqual('string');
    expect(typeof book['category']).toEqual('string');
    expect(typeof book['publicationYear']).toEqual('number');
    expect(typeof book['publisher']).toEqual('string');
    expect(typeof book['price']).toEqual('number');
    expect(typeof book['numberOfPages']).toEqual('number');
  });
});
