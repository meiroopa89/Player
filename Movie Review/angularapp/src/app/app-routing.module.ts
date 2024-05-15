import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReviewListComponent } from './review-list/review-list.component';
import { AddReviewComponent } from './add-review/add-review.component';

const routes: Routes = [
  { path: 'addReview', component: AddReviewComponent },
  { path: 'viewReviews', component: ReviewListComponent },
  { path: '', redirectTo: '/viewReviews', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
