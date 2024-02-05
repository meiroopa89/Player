import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';

import { BookService } from '../services/book.service';
import { BookFormComponent } from './book-form.component';

describe('BookFormComponent', () => {
    let component: BookFormComponent;
    let fixture: ComponentFixture<BookFormComponent>;
    let bookService: BookService;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [FormsModule, HttpClientTestingModule],
            declarations: [BookFormComponent],
            providers: [BookService]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(BookFormComponent);
        component = fixture.componentInstance;
        bookService = TestBed.inject(BookService);
    });

    fit('should create BookFormComponent', () => {
        expect(component).toBeTruthy();
    });

    fit('BookFormComponent_should have a form for adding a book', () => {
        const formElement: HTMLFormElement = fixture.nativeElement.querySelector('form');
        expect(formElement).toBeTruthy();
    });

    fit('BookFormComponent_should have form controls for book details, author, category, publication year, publisher, price, and number of pages', () => {
        const formElement: HTMLFormElement = fixture.nativeElement.querySelector('form');
        expect(formElement.querySelector('#title')).toBeTruthy();
        expect(formElement.querySelector('#author')).toBeTruthy();
        expect(formElement.querySelector('#category')).toBeTruthy();
        expect(formElement.querySelector('#publicationYear')).toBeTruthy();
        expect(formElement.querySelector('#publisher')).toBeTruthy();
        expect(formElement.querySelector('#price')).toBeTruthy();
        expect(formElement.querySelector('#numberOfPages')).toBeTruthy();
    });

    fit('BookFormComponent_should have a button for adding a book', () => {
        const buttonElement: HTMLButtonElement = fixture.nativeElement.querySelector('button');
        expect(buttonElement).toBeTruthy();
        expect(buttonElement.textContent).toContain('Add Book');
    });

    fit('BookFormComponent_should have addBook method', () => {
        expect(component['addBook']).toBeTruthy();
    });

});
