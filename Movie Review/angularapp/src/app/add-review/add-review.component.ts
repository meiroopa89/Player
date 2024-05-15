import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Review } from '../models/review.model';
import { ReviewService } from '../services/review.service';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent {
  review: Review = {
    reviewId: 0,
    movieName: '',
    movieDirector: '',
    leadCast: '',
    movieReviewDate: null,
    movieReleaseDate: null,
    reviewComments: '',
    rating: 0
  }; // Initialize review with empty fields

  formSubmitted = false; // Track form submission

  constructor(private reviewService: ReviewService, private router: Router) { }

  AddNewReview(): void {
    this.formSubmitted = true; // Set formSubmitted to true on form submission
    if (this.isFormValid()) {
      this.reviewService.addReview(this.review).subscribe(() => {
        console.log('Movie review added successfully!');
        // Optionally, you can navigate to another route after submission
        this.router.navigate(['/viewReviews']);
      });
    }
  }
  
  isFieldInvalid(fieldName: string): boolean {
    const fieldValue = this.review[fieldName];
    return !fieldValue && (this.formSubmitted || fieldValue?.touched);
  }

  isFormValid(): boolean {
    return !this.isFieldInvalid('movieName') && !this.isFieldInvalid('movieDirector') &&
      !this.isFieldInvalid('leadCast') && !this.isFieldInvalid('movieReleaseDate') &&
      !this.isFieldInvalid('movieReviewDate') && !this.isFieldInvalid('reviewComments') &&
      !this.isFieldInvalid('rating');
  }
}
