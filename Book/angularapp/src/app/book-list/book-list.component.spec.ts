// book-list.component.spec.ts
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { BookService } from '../services/book.service';
import { BookListComponent } from './book-list.component';

describe('BookListComponent', () => {
    let component: BookListComponent;
    let fixture: ComponentFixture<BookListComponent>;
    let mockBookService;

    beforeEach(async () => {
        mockBookService = jasmine.createSpyObj(['getBooks']);

        await TestBed.configureTestingModule({
            declarations: [BookListComponent],
            providers: [
                { provide: BookService, useValue: mockBookService }
            ]
        })
            .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(BookListComponent);
        component = fixture.componentInstance;
    });

    fit('should create book-listComponent', () => {
        mockBookService.getBooks.and.returnValue(of([]));
        fixture.detectChanges();
        expect(component).toBeTruthy();
    });

    fit('book-listComponent_should call loadBooks on ngOnInit', () => {
        spyOn(component, 'loadBooks');
        fixture.detectChanges();
        expect(component['loadBooks']).toHaveBeenCalled();
    });

});