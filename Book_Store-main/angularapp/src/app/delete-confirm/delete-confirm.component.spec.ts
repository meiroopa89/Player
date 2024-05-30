import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { DeleteConfirmComponent } from './delete-confirm.component';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { BookService } from '../services/book.service'; // Adjusted service name

describe('DeleteConfirmComponent', () => {
    let component: DeleteConfirmComponent;
    let fixture: ComponentFixture<DeleteConfirmComponent>;
    let router: Router;
    let activatedRoute: ActivatedRoute;
    let mockBookService: jasmine.SpyObj<BookService>; // Adjusted service name

    beforeEach(waitForAsync(() => {
        mockBookService = jasmine.createSpyObj<BookService>('BookService', ['getBook', 'deleteBook']); // Adjusted service name and methods

        TestBed.configureTestingModule({
            imports: [RouterTestingModule, HttpClientModule, FormsModule, HttpClientTestingModule],
            declarations: [DeleteConfirmComponent],
            providers: [
                { provide: BookService, useValue: mockBookService } // Adjusted service name
            ]
        }).compileComponents();
        router = TestBed.inject(Router);
        activatedRoute = TestBed.inject(ActivatedRoute);
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(DeleteConfirmComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    fit('should_create_DeleteConfirmComponent', () => {
        expect(component).toBeTruthy();
    });

    fit('DeleteConfirmComponent_should_call_deleteBook_method_when_confirmDelete_is_called', () => {
        const bookId = 1; // Adjusted ID name

        mockBookService.deleteBook.and.returnValue(of(null)); // Adjusted method name

        component.confirmDelete(bookId); // Adjusted parameter name

        expect(mockBookService.deleteBook).toHaveBeenCalledWith(bookId); // Adjusted method name and parameter
    });
});

