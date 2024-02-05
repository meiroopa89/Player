// expense.component.ts
import { Component } from '@angular/core';
import { ExpenseService } from '../services/expense.service';

@Component({
  selector: 'app-expense',
  templateUrl: './expense.component.html',
  styleUrls: ['./expense.component.css']
})
export class ExpenseComponent {
  expenseDetails: string;
  category: string;
  amount: number;
  paymentMode: string;
  expenseDate: string;

  constructor(private expenseService: ExpenseService) {}

  addExpense() {
    const newExpense = {
      expenseDetails: this.expenseDetails,
      category: this.category,
      amount: this.amount,
      paymentMode: this.paymentMode,
      expenseDate: this.expenseDate
    };
    console.log(newExpense);
    

    this.expenseService.addExpense(newExpense).subscribe(
      response => {
        console.log('Expense added successfully:', response);
        // Optionally, you can reset the form fields after a successful submission
        this.resetForm();
      },
      error => {
        console.error('Error adding expense:', error);
      }
    );
  }

  private resetForm() {
    this.expenseDetails = '';
    this.category = '';
    this.amount = null;
    this.paymentMode = '';
    this.expenseDate = '';
  }
}
