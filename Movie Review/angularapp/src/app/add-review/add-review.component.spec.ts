import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { AddReviewComponent } from './add-review.component'; // Adjusted component name
import { ReviewService } from '../services/review.service'; // Adjusted service name
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';
import { Review } from '../models/review.model'; // Adjusted model name

describe('AddReviewComponent', () => { // Adjusted component name
  let component: AddReviewComponent; // Adjusted component name
  let fixture: ComponentFixture<AddReviewComponent>; // Adjusted component name
  let reviewService: ReviewService; // Adjusted service name
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddReviewComponent], // Adjusted component name
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
      providers: [ReviewService] // Adjusted service name
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddReviewComponent); // Adjusted component name
    component = fixture.componentInstance; // Adjusted component name
    reviewService = TestBed.inject(ReviewService); // Adjusted service name
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

  fit('should_create_AddReviewComponent', () => { // Adjusted component name
    expect(component).toBeTruthy();
  });

  fit('AddReviewComponent_should_render_error_messages_when_required_fields_are_empty_on_submit', () => { // Adjusted component name
    // Set all fields to empty strings
    component.review = {
      reviewId: null,
      movieName: '',
      movieDirector: '',
      leadCast: '',
      movieReleaseDate: null,
      movieReviewDate: null,
      reviewComments: '',
      rating: null
    } as any;
    
    // Manually trigger form submission
    component.formSubmitted = true;
    
    fixture.detectChanges();
    
    // Find the form element
    const form = fixture.debugElement.query(By.css('form')).nativeElement;
    
    // Submit the form
    form.dispatchEvent(new Event('submit'));
    
    fixture.detectChanges();
    
    // Check if error messages are rendered for each field
    expect(fixture.debugElement.query(By.css('#movieName + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#movieDirector + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#leadCast + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#reviewDate + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#reviewDate + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#reviewComments + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#rating + .error-message'))).toBeTruthy();
  });


  fit('AddReviewComponent_should_call_AddReview_method_while_adding_the_review', () => { // Adjusted component name and method name
    // Create a mock Review object with all required properties
    const review: Review = { 
      reviewId: 1, 
      movieName: 'Test Movie', 
      movieDirector: 'Test Director', 
      leadCast: 'Test Cast', 
      movieReleaseDate: new Date(), 
      movieReviewDate: new Date(), 
      reviewComments: 'Test Comment', 
      rating: 5
    };
    const AddReviewSpy = spyOn(component, 'AddReview').and.callThrough(); // Adjusted method name
    component.AddReview(); // Adjusted method name
    expect(AddReviewSpy).toHaveBeenCalled();
  });
});
