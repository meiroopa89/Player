import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FormsModule } from '@angular/forms';
import { ReviewListComponent } from './review-list.component';
import { ReviewService } from '../services/review.service';
import { of } from 'rxjs';
import { Review } from '../models/review.model';

describe('ReviewListComponent', () => {
  let component: ReviewListComponent;
  let fixture: ComponentFixture<ReviewListComponent>;
  let reviewService: jasmine.SpyObj<ReviewService>;

  beforeEach(() => {
    const reviewServiceSpy = jasmine.createSpyObj('ReviewService', ['getReviews', 'deleteReview']);

    TestBed.configureTestingModule({
      declarations: [ReviewListComponent],
      imports: [HttpClientTestingModule, FormsModule],
      providers: [{ provide: ReviewService, useValue: reviewServiceSpy }],
    });

    fixture = TestBed.createComponent(ReviewListComponent);
    component = fixture.componentInstance;
    reviewService = TestBed.inject(ReviewService) as jasmine.SpyObj<ReviewService>;
  });

  fit('ReviewListComponent_should_create', () => {
    expect(component).toBeTruthy();
  });

  fit('ReviewListComponent_should fetch reviews on init', () => {
    const dummyReviews: Review[] = [
      { reviewId: 1, movieName: 'Movie 1', movieDirector: 'Director 1', leadCast: 'Lead Cast 1',
        movieReleaseDate: new Date(), movieReviewDate: new Date(), reviewComments: 'Comment 1', rating: 5 },
      { reviewId: 2, movieName: 'Movie 2', movieDirector: 'Director 2', leadCast: 'Lead Cast 2',
        movieReleaseDate: new Date(), movieReviewDate: new Date(), reviewComments: 'Comment 2', rating: 4 },
    ];

    reviewService['getReviews'].and.returnValue(of(dummyReviews));

    fixture.detectChanges();

    expect(component['reviews']).toEqual(dummyReviews);
  });

});
