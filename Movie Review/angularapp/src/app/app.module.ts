import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ReviewListComponent } from './review-list/review-list.component';
import { AddReviewComponent } from './add-review/add-review.component';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';

@NgModule({
  declarations: [
    AppComponent,
    ReviewListComponent,
    AddReviewComponent,
    DeleteConfirmComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
