import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExpenseService {
  static addExpense(mockExpense: { expenseDetails: string; category: string; amount: number; paymentMode: string; expenseDate: string; }) {
    throw new Error('Method not implemented.');
  }
  public apiUrl = 'https://localhost:7022/';

  constructor(private http: HttpClient) { }

  addExpense(expense: any): Observable<any> {
    console.log(expense);
    
    return this.http.post<any>(`${this.apiUrl}api/expense`, expense);
  }


  getExpenses(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}api/expense`);
  }

  // addBlog(blog: Blogmodel): Observable<Blogmodel> {
  //   console.log('Adding Blog:', blog);
  //   return this.http.post<Blogmodel>(${this.apiUrl}, blog);
  // }
  
  // getBlogs(): Observable<Blogmodel[]> {
  //   console.log('Getting Blogs');
  //   return this.http.get<Blogmodel[]>(${this.apiUrl});
  // }
}
