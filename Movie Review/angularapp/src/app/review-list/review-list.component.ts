import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReviewService } from '../services/review.service'; // Adjusted service name
import { Review } from '../models/review.model'; // Adjusted model name

@Component({
  selector: 'app-review-list', // Adjusted selector
  templateUrl: './review-list.component.html', // Adjusted template URL
  styleUrls: ['./review-list.component.css'] // Adjusted style URL
})
export class ReviewListComponent implements OnInit {
  reviews: Review[] = []; // Adjusted property name

  constructor(private reviewService: ReviewService, private router: Router) { } // Adjusted service name

  ngOnInit(): void {
    this.loadReviews(); // Adjusted method name
  }

  loadReviews(): void {
    this.reviewService.getReviews().subscribe(reviews => { // Adjusted method name
      this.reviews = reviews;
      console.log(this.reviews);
    });
  }

  deleteReview(reviewId: number): void { // Adjusted method name and parameter
    // Navigate to confirm delete page with the review ID as a parameter
    this.router.navigate(['/confirmDelete', reviewId]);
  }
}
