import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ReviewListComponent } from './review-list.component'; // Adjusted component name
import { ReviewService } from '../services/review.service'; // Adjusted service name

describe('ReviewListComponent', () => { // Adjusted component name
    let component: ReviewListComponent; // Adjusted component name
    let fixture: ComponentFixture<ReviewListComponent>; // Adjusted component name
    let mockReviewService: jasmine.SpyObj<ReviewService>; // Specify the type of mock

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockReviewService = jasmine.createSpyObj<ReviewService>('ReviewService', ['getReviews', 'deleteReview'] as any); // Adjusted service name

        TestBed.configureTestingModule({
            declarations: [ReviewListComponent], // Adjusted component name
            imports: [RouterTestingModule, HttpClientTestingModule],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: ReviewService, useValue: mockReviewService } // Adjusted service name
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(ReviewListComponent); // Adjusted component name
        component = fixture.componentInstance; // Adjusted component name
    });

    fit('should_create_ReviewListComponent', () => { // Adjusted function name and component name
        expect(component).toBeTruthy();
    });

    fit('ReviewListComponent_should_call_loadReviews_on_ngOnInit', () => { // Adjusted function name and method name
        spyOn(component, 'loadReviews'); // Adjusted method name
        fixture.detectChanges();
        expect(component.loadReviews).toHaveBeenCalled(); // Adjusted method name
    });

});
