import { Review } from "./review.model";

describe('Review Model', () => {

  fit('Review Model should create an instance of Review', () => {
    const review: Review = {
      reviewId: 1,
      movieName: 'Movie 1',
      movieDirector: 'Director 1',
      leadCast: 'Actor 1',
      movieReleaseDate: new Date(),
      movieReviewDate: new Date(),
      reviewComments: 'Great movie!',
      rating: 5
    };

    expect(review).toBeTruthy();
    expect(review.reviewId).toBe(1);
    expect(review.movieName).toBe('Movie 1');
    expect(review.movieDirector).toBe('Director 1');
    expect(review.leadCast).toBe('Actor 1');
    expect(review.movieReleaseDate).toBeTruthy();
    expect(review.movieReviewDate).toBeTruthy();
    expect(review.reviewComments).toBe('Great movie!');
    expect(review.rating).toBe(5);
  });
});
