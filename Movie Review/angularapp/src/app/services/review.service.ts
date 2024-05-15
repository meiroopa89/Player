// review.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Review } from '../models/review.model';

@Injectable({
    providedIn: 'root'
})
export class ReviewService {
    private apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io'; // Update with your API endpoint

    constructor(private http: HttpClient) { }

    getReviews(): Observable<Review[]> {
        return this.http.get<Review[]>(`${this.apiUrl}/api/Review`);
    }

    addReview(review: Review): Observable<Review> {
        return this.http.post<Review>(`${this.apiUrl}/api/Review`, review);
    }

    deleteReview(id: number): Observable<Review> {
        return this.http.delete<Review>(`${this.apiUrl}/api/${id}`);
      }
      
}
