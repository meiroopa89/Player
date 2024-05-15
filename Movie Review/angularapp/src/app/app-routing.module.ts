import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReviewListComponent } from './review-list/review-list.component';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';
import { AddReviewComponent } from './add-review/add-review.component';

const routes: Routes = [
  { path: 'addReview', component: AddReviewComponent },
  { path: 'viewReviews', component: ReviewListComponent },
  { path: '', redirectTo: '/viewReviews', pathMatch: 'full' },
  { path: 'confirmDelete/:id', component: DeleteConfirmComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
