import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { DeleteConfirmComponent } from './delete-confirm.component';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ReviewService } from '../services/review.service'; // Adjusted service name

describe('DeleteConfirmComponent', () => {
    let component: DeleteConfirmComponent;
    let fixture: ComponentFixture<DeleteConfirmComponent>;
    let router: Router;
    let activatedRoute: ActivatedRoute;
    let mockReviewService: jasmine.SpyObj<ReviewService>; // Adjusted service name

    beforeEach(waitForAsync(() => {
        mockReviewService = jasmine.createSpyObj<ReviewService>('ReviewService', ['getReview', 'deleteReview'] as any); // Adjusted service name and methods

        TestBed.configureTestingModule({
            imports: [RouterTestingModule, HttpClientModule, FormsModule, HttpClientTestingModule],
            declarations: [DeleteConfirmComponent],
            providers: [
                { provide: ReviewService, useValue: mockReviewService } // Adjusted service name
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

    fit('DeleteConfirmComponent_should_call_deleteReview_method_when_confirmDelete_is_called', () => {
        const reviewId = 1; // Adjusted ID name
        
        mockReviewService.deleteReview.and.returnValue(of(null)); // Adjusted method name

        component.confirmDelete(reviewId); // Adjusted parameter name

        expect(mockReviewService.deleteReview).toHaveBeenCalledWith(reviewId); // Adjusted method name and parameter
    });
});
