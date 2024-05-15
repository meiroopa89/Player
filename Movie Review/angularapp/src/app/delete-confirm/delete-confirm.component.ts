// import { Component, OnInit } from '@angular/core';
// import { ActivatedRoute, Router } from '@angular/router';
// import { ReviewService } from '../services/review.service'; // Adjusted service name
// import { Review } from '../models/review.model';

// @Component({
//   selector: 'app-delete-confirm', // Adjusted component selector
//   templateUrl: './delete-confirm.component.html',
//   styleUrls: ['./delete-confirm.component.css']
// })
// export class DeleteConfirmComponent implements OnInit {
//   id: number;
//   review: Review;

//   constructor(
//     private route: ActivatedRoute, 
//     private router: Router,
//     private reviewService: ReviewService // Adjusted service name
//   ) { }

//   ngOnInit(): void {
//     this.route.params.subscribe(params => {
//       this.id = +params['id']; // Adjust parameter name
//     });
//   }

//   confirmDelete(reviewId: number): void {
//     this.reviewService.deleteReview(reviewId).subscribe(
//       () => {
//         console.log('Review deleted successfully.');
//         this.router.navigate(['/viewReviews']); // Adjust the route
//       },
//       (error) => {
//         console.error('Error deleting review:', error);
//       }
//     );
//   }

//   cancelDelete(): void {
//     this.router.navigate(['/viewReviews']); // Adjust the route
//   }
// }


import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Review } from '../models/review.model'; // Adjusted model name
import { ReviewService } from '../services/review.service'; // Adjusted service name

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
      this.reviewService.getReviews().subscribe(
        (reviews: Review[]) => {
          const foundReview = reviews.find(review => review.reviewId === this.reviewId);
          if (foundReview) {
            this.review = foundReview;
          } else {
            console.error('Review not found.');
          }
        },
        error => {
          console.error('Error fetching reviews:', error);
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
