import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewService } from '../services/review.service'; // Adjusted service name

@Component({
  selector: 'app-delete-confirm', // Adjusted component selector
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  reviewId: number;

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private reviewService: ReviewService // Adjusted service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.reviewId = +params['id']; // Adjust parameter name
    });
  }

  confirmDelete(reviewId: number): void {
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
