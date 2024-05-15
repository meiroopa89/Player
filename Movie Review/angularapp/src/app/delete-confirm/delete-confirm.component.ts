import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Review } from '../models/review.model'; // Import the Review model
import { ReviewService } from '../services/review.service'; // Import the ReviewService

@Component({
  selector: 'app-delete-confirm', // Adjusted component selector
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  reviewId: number;
  review: Review = {} as Review; // Initialize review property with an empty object

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private reviewService: ReviewService // Adjusted service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.reviewId = +params['id']; // Adjust parameter name
      this.reviewService.getReview(this.reviewId).subscribe(
        (review: Review) => {
          this.review = review;
        },
        error => {
          console.error('Error fetching review:', error);
        }
      );
    });
  }

  confirmDelete(reviewId: number): void { // Adjust method signature
    this.reviewService.deleteReview(reviewId).subscribe(
      () => {
        console.log('Review deleted successfully.');
        this.router.navigate(['/viewReviews']); // Adjust the route
      },
      (error) => {
        console.error('Error deleting review:', error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/viewReviews']); // Adjust the route
  }
}
