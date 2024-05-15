import { Component, OnInit } from '@angular/core';
import { ReviewService } from '../services/review.service';
import { Review } from '../models/review.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-review-list',
  templateUrl: './review-list.component.html',
  styleUrls: ['./review-list.component.css']
})
export class ReviewListComponent implements OnInit {
  reviews: Review[] = [];
  selectedReview: Review;


  constructor(private reviewService: ReviewService, private router: Router) { }

  ngOnInit(): void {
    this.reviewService.getReviews().subscribe(reviews => {
      this.reviews = reviews;
    });
  }

  getReviews(): void {
    this.reviewService.getReviews().subscribe((reviews) => (this.reviews = reviews));
  }

  // deleteReview(id: number): void {
  //   this.reviewService.deleteReview(id).subscribe(() => this.getReviews());
  // }

  // deleteReview(reviewId: number): void {
  //   if (reviewId) {
  //     this.router.navigate(['/confirmDelete', reviewId]);
  //   } else {
  //     console.error('Review ID is undefined.');
  //   }
  // }

  deleteReview(review: Review): void {
    if (review) {
      this.router.navigate(['/confirmDelete', review.reviewId], { state: { review } });
    } else {
      console.error('Review is undefined.');
    }
  }
  
  
  

}
