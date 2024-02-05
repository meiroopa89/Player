// dashboard.component.ts
import { Component, OnInit } from '@angular/core';
import { ExpenseService } from '../services/expense.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  expenses: any[];

  constructor(private expenseService: ExpenseService) {}

  ngOnInit() {
    this.loadExpenses();
  }

  loadExpenses() {
    this.expenseService.getExpenses().subscribe(
      data => {
        this.expenses = data;
      },
      error => {
        console.error('Error fetching expenses:', error);
      }
    );
  }
}
