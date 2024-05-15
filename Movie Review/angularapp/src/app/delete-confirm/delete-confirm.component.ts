import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Review } from '../models/review.model';
import { ReviewService } from '../services/review.service';

@Component({
  selector: 'app-delete-confirm',
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  reviewId: number;
  review: Review = {} as Review;

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private reviewService: ReviewService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.reviewId = +params['id'];
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

  confirmDelete(reviewId: number): void {
    this.reviewService.deleteReview(reviewId).subscribe(
      () => {
        console.log('Review deleted successfully.');
        this.router.navigate(['/viewReviews']);
      },
      (error) => {
        console.error('Error deleting review:', error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/viewReviews']);
  }
}
