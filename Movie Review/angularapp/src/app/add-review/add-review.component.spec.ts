import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { AddReviewComponent } from './add-review.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('AddReviewComponent (HTML)', () => {
  let fixture: ComponentFixture<AddReviewComponent>;
  let component: AddReviewComponent;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddReviewComponent],
      imports: [FormsModule, HttpClientTestingModule],
    });

    fixture = TestBed.createComponent(AddReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  fit('AddReviewComponent_should be created', () => {
    expect(component).toBeTruthy();
  });

  fit('AddReviewComponent_should display error message for Movie Name when touched and invalid', () => {
    const movieNameInput = fixture.nativeElement.querySelector('#movieName');
    movieNameInput.value = ''; // Set an invalid value
    movieNameInput.dispatchEvent(new Event('input'));

    fixture.detectChanges();

    const errorMessage = fixture.nativeElement.querySelector('.error-message');
    expect(errorMessage.textContent).toContain('Movie Name is required');
  });

  fit('AddReviewComponent_should display error message for Movie Director when touched and invalid', () => {
    const movieDirectorInput = fixture.nativeElement.querySelector('#movieDirector');
    movieDirectorInput.value = ''; // Set an invalid value
    movieDirectorInput.dispatchEvent(new Event('input'));

    fixture.detectChanges();

    const errorMessage = fixture.nativeElement.querySelector('.error-message');
    expect(errorMessage.textContent).toContain('Movie Director is required');
  });

  // Repeat similar tests for Lead Cast, Release Date, Review Date, Review Comments, and Rating

  it('AddReviewComponent_should not display error message for Movie Name when untouched', () => {
    const errorMessage = fixture.nativeElement.querySelector('.error-message');
    expect(errorMessage).toBeFalsy();
  });

  fit('AddReviewComponent_should call submitReview method on form submission', () => {
    spyOn(component as any, 'submitReview');

    const submitButton = fixture.nativeElement.querySelector('button[type="submit"]');
    submitButton.click();

    expect(component['submitReview']).toHaveBeenCalled();
  });

  fit('AddReviewComponent_should display error message for Rating when touched and invalid', fakeAsync(() => {
    const ratingInput = fixture.nativeElement.querySelector('#rating');
    ratingInput.value = ''; // Set an invalid value
    ratingInput.dispatchEvent(new Event('input'));

    tick(); // Wait for asynchronous validation to complete
    fixture.detectChanges();

    const errorMessage = fixture.nativeElement.querySelector('.error-message');
    expect(errorMessage.textContent).toContain('Rating is required');
  }));

  it('AddReviewComponent_should not display error message for Rating when untouched', fakeAsync(() => {
    const errorMessage = fixture.nativeElement.querySelector('.error-message');
    expect(errorMessage).toBeFalsy();
  }));

  fit('AddReviewComponent_should submit the form when all fields are valid', fakeAsync(() => {
    spyOn(component as any, 'submitReview');

    // Set valid values for all fields
    component['review'] = {
      movieName: 'Valid Movie',
      movieDirector: 'Valid Director',
      leadCast: 'Valid Cast',
      movieReleaseDate: '2023-01-01',
      movieReviewDate: '2023-01-02',
      reviewComments: 'Valid Comment',
      rating: 4,
    };

    // Trigger form submission
    const submitButton = fixture.nativeElement.querySelector('button[type="submit"]');
    submitButton.click();

    tick(); // Wait for asynchronous operations to complete
    fixture.detectChanges();

    expect(component['submitReview']).toHaveBeenCalled();
  }));

  // Add more tests as needed to cover other aspects of your HTML template
});
