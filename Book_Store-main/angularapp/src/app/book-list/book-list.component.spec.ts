import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { BookListComponent } from './book-list.component'; // Adjusted component name
import { BookService } from '../services/book.service'; // Adjusted service name

describe('BookListComponent', () => { // Adjusted component name
    let component: BookListComponent; // Adjusted component name
    let fixture: ComponentFixture<BookListComponent>; // Adjusted component name
    let mockBookService: jasmine.SpyObj<BookService>; // Specify the type of mock

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockBookService = jasmine.createSpyObj<BookService>('BookService', ['getBooks', 'deleteBook'] as any); // Adjusted service name

        TestBed.configureTestingModule({
            declarations: [BookListComponent], // Adjusted component name
            imports: [RouterTestingModule, HttpClientTestingModule],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: BookService, useValue: mockBookService } // Adjusted service name
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(BookListComponent); // Adjusted component name
        component = fixture.componentInstance; // Adjusted component name
    });

    fit('should_create_BookListComponent', () => { // Adjusted function name and component name
        expect(component).toBeTruthy();
    });

    fit('BookListComponent_should_call_loadBooks_on_ngOnInit', () => { // Adjusted function name and method name
        spyOn(component, 'loadBooks'); // Adjusted method name
        fixture.detectChanges();
        expect(component.loadBooks).toHaveBeenCalled(); // Adjusted method name
    });

});
