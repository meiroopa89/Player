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
  public apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/';

  constructor(private http: HttpClient) { }

  addExpense(expense: any): Observable<any> {
    console.log(expense);
    
    return this.http.post<any>(`${this.apiUrl}api/expense`, expense);
  }


  getExpenses(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}api/expense`);
  }
}
