import { Component, OnInit } from '@angular/core';
import { ReviewService } from '../services/review.service';
import { Review } from '../models/review.model';

@Component({
  selector: 'app-review-list',
  templateUrl: './review-list.component.html',
  styleUrls: ['./review-list.component.css']
})
export class ReviewListComponent implements OnInit {
  reviews: Review[] = [];
  selectedReview: Review;


  constructor(private reviewService: ReviewService, private router: Rou) { }

  ngOnInit(): void {
    this.reviewService.getReviews().subscribe(reviews => {
      this.reviews = reviews;
    });
  }

  getReviews(): void {
    this.reviewService.getReviews().subscribe((reviews) => (this.reviews = reviews));
  }

  deleteReview(id: number): void {
    this.reviewService.deleteReview(id).subscribe(() => this.getReviews());
  }

  deleteFlight(flightId: number): void { // Adjusted method name and parameter
    // Navigate to confirm delete page with the flight ID as a parameter
    this.router.navigate(['/confirmDelete', flightId]);
  }

}
