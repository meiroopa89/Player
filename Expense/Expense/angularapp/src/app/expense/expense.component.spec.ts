// expense.component.spec.ts
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { throwError } from 'rxjs';

import { ExpenseService } from '../services/expense.service';
import { ExpenseComponent } from './expense.component';

describe('ExpenseComponent', () => {
  let component: ExpenseComponent;
  let fixture: ComponentFixture<ExpenseComponent>;
  let expenseService: ExpenseService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [ExpenseComponent],
      providers: [ExpenseService]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpenseComponent);
    component = fixture.componentInstance;
    expenseService = TestBed.inject(ExpenseService);
  });

// Check if ExpenseComponent is created
fit('should create ExpenseComponent', () => {
  expect(component).toBeTruthy();
});

// Check if ExpenseComponent has a form for adding expenses
fit('should have a form for adding expense', () => {
  const formElement: HTMLFormElement = fixture.nativeElement.querySelector('form');
  expect(formElement).toBeTruthy();
});

//should have form controls for expense details, category, amount, payment mode, and expense date
fit('should have form controls for expense details, category, amount, payment mode, and expense date', () => {
  const formElement: HTMLFormElement = fixture.nativeElement.querySelector('form');
  expect(formElement.querySelector('#expenseDetails')).toBeTruthy();
  expect(formElement.querySelector('#category')).toBeTruthy();
  expect(formElement.querySelector('#amount')).toBeTruthy();
  expect(formElement.querySelector('#paymentMode')).toBeTruthy();
  expect(formElement.querySelector('#expenseDate')).toBeTruthy();
});

//should have a button for adding expense
fit('should have a button for adding expense', () => {
  const buttonElement: HTMLButtonElement = fixture.nativeElement.querySelector('button');
  expect(buttonElement).toBeTruthy();
  expect(buttonElement.textContent).toContain('Add Expense');
});

//should have add expense method that calls expense service to add an
fit('should have addExpense method', () => {
  expect(component['addExpense']).toBeTruthy();
});

//should handle error when adding an expense fails
fit('should handle error when adding an expense fails', () => {
  const errorResponse = new ErrorEvent('Network error');
  spyOn(expenseService, 'addExpense').and.returnValue(throwError(errorResponse));
  spyOn(console, 'error');
  component.addExpense();
  expect(console.error).toHaveBeenCalledWith('Error adding expense:', errorResponse);
});

});