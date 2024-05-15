import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ReviewService } from './review.service';
import { Review } from '../models/review.model';

describe('ReviewService', () => {
  let service: ReviewService;
  let httpMock: HttpTestingController;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ReviewService],
    });

    service = TestBed.inject(ReviewService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  fit('ReviewService_should be created', () => {
    expect(service).toBeTruthy();
  });

  fit('ReviewService_getReviews_should get all reviews', () => {
    const dummyReviews: Review[] = [
        { reviewId: 1, movieName: 'Movie 1', movieDirector: 'Director 1', leadCast: 'Lead Cast 1',
            movieReleaseDate: new Date(), movieReviewDate: new Date(), reviewComments: 'Comment 1', rating: 5 },
        { reviewId: 2, movieName: 'Movie 2', movieDirector: 'Director 2', leadCast: 'Lead Cast 2',
            movieReleaseDate: new Date(), movieReviewDate: new Date(), reviewComments: 'Comment 2', rating: 4 },
    ];

    service.getReviews().subscribe(reviews => {
        expect(reviews.length).toBe(2); // Adjust the expected length based on your dummy data
        expect(reviews).toEqual(dummyReviews);
    });

    const req = httpMock.expectOne(`${service['apiUrl']}/api/Review`); // Adjusted URL
    expect(req.request.method).toBe('GET');
    req.flush(dummyReviews);
});

  fit('ReviewService_addReview_should add a review', () => {
    const newReview: Review = {
      reviewId: 3, movieName: 'New Movie', movieDirector: 'New Director', leadCast: 'New Lead Cast',
      movieReleaseDate: new Date(), movieReviewDate: new Date(), reviewComments: 'New Comment', rating: 4,
    };

    service.addReview(newReview).subscribe(review => {
      expect(review).toEqual(newReview);
    });

    const req = httpMock.expectOne(`${service['apiUrl']}/api/Review`); // Adjusted URL
    expect(req.request.method).toBe('POST');
    req.flush(newReview);
});

  fit('ReviewService_should_delete_Review', () => {
    const reviewId = 100;

    service.deleteReview(reviewId).subscribe(() => {
      expect().nothing();
    });

    const req = httpMock.expectOne(`${service['apiUrl']}/api/Review/${reviewId}`); // Adjusted URL
    expect(req.request.method).toBe('DELETE');
    req.flush({});
});

  fit('ReviewService_should_get_Review_by_id', () => {
    const reviewId = 100;
    const mockReview: Review = {
      reviewId: reviewId,
      movieName: 'Test Movie',
      movieDirector: 'Test Director',
      leadCast: 'Test Lead Cast',
      movieReleaseDate: new Date(),
      movieReviewDate: new Date(),
      reviewComments: 'Test Comments',
      rating: 5
    };

    service.getReview(reviewId).subscribe((review) => {
      expect(review).toEqual(mockReview);
    });

    const req = httpMock.expectOne(`${service['apiUrl']}/api/Review/${reviewId}`); // Adjusted URL
    expect(req.request.method).toBe('GET');
    req.flush(mockReview);
});

  
});
