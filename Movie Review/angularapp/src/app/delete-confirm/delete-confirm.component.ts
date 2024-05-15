import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewService } from '../services/review.service'; // Adjusted service name
import { Review } from '../models/review.model';

@Component({
  selector: 'app-delete-confirm', // Adjusted component selector
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  id: number;
  review: Review;

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private reviewService: ReviewService // Adjusted service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id']; // Adjust parameter name
    });
  }

  confirmDelete(id: number): void {
    this.reviewService.deleteReview(id).subscribe(
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
