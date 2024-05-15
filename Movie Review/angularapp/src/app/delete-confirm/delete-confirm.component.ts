import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewService } from '../services/review.service';
import { Review } from '../models/review.model';

@Component({
  selector: 'app-delete-confirm',
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  review: Review;

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private reviewService: ReviewService
  ) { }

  ngOnInit(): void {
    // Retrieve review object from route snapshot
    this.review = this.route.snapshot.data.review;
  }

  confirmDelete(): void {
    if (this.review) {
      this.reviewService.deleteReview(this.review.reviewId).subscribe(
        () => {
          console.log('Review deleted successfully.');
          this.router.navigate(['/viewReviews']);
        },
        (error) => {
          console.error('Error deleting review:', error);
        }
      );
    }
  }

  cancelDelete(): void {
    this.router.navigate(['/viewReviews']);
  }
}
