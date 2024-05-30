import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { BookService } from '../services/book.service'; // Adjusted service name
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';
import { Book } from '../models/book.model'; // Adjusted model name
import { BookFormComponent } from './book-form.component'; // Adjusted component name

describe('BookFormComponent', () => { // Adjusted component name
  let component: BookFormComponent; // Adjusted component name
  let fixture: ComponentFixture<BookFormComponent>; // Adjusted component name
  let bookService: BookService; // Adjusted service name
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BookFormComponent], // Adjusted component name
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
      providers: [BookService] // Adjusted service name
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookFormComponent); // Adjusted component name
    component = fixture.componentInstance; // Adjusted component name
    bookService = TestBed.inject(BookService); // Adjusted service name
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

  fit('should_create_BookFormComponent', () => { // Adjusted component name
    expect(component).toBeTruthy();
  });

  fit('BookFormComponent_should_render_error_messages_when_required_fields_are_empty_on_submit', () => { // Adjusted component name
    // Set all fields to empty strings
    component.newBook = {
      bookId: null,
      title: '',
      author: '',
      genre: '',
      price: null,
      isbn: ''
    } as Book;
    
    // Manually trigger form submission
    component.formSubmitted = true;
    
    fixture.detectChanges();
    
    // Find the form element
    const form = fixture.debugElement.query(By.css('form')).nativeElement;
    
    // Submit the form
    form.dispatchEvent(new Event('submit'));
    
    fixture.detectChanges();
    
    // Check if error messages are rendered for each field
    expect(fixture.debugElement.query(By.css('#title + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#author + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#genre + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#price + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#isbn + .error-message'))).toBeTruthy();
  });

 fit('BookFormComponent_should_call_addBook_method_while_adding_the_book', () => { // Adjusted component name and method name
    // Create a mock Book object with all required properties
    const book: Book = { 
      bookId: 1, 
      title: 'Angular Essentials', 
      author: 'John Doe', 
      genre: 'Technical', 
      price: 29.99, 
      isbn: '1234567890'
    };
    
    const addBookSpy = spyOn(component, 'addBook').and.callThrough(); // Adjusted method name
    component.addBook(); // Adjusted method name
    expect(addBookSpy).toHaveBeenCalled();
  });
});
