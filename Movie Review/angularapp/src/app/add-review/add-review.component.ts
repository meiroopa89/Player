import { Component, OnInit } from '@angular/core';
import { ReviewService } from '../services/review.service';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {

  review: any = {};

  constructor(private reviewService: ReviewService) { }

  ngOnInit(): void {
  }

  submitReview() {
    if (this.review.rating < 1 || this.review.rating > 5) {
      alert('Rating must be between 1 and 5.');
      return; // Don't submit the review if the rating is invalid
    }
    if (this.review.movieName == '' || this.review.movieDirector == '' || this.review.leadCast == '' || this.review.reviewComments == '' || this.review.rating == '' || this.review.movieReleaseDate == '' || this.review.movieReviewDate == '') {
      return; // Don't submit the review if the rating is invalid
    }
    this.reviewService.addReview(this.review).subscribe(response => {
      console.log('Review submitted successfully:', response);
      window.location.href = '/viewReviews';

      // You can navigate to another page or reset the form here
    });

  }

}
