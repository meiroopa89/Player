import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { ExpenseService } from './expense.service';

describe('ExpenseService', () => {
  let service: ExpenseService;
  let httpTestingController: HttpTestingController;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
    });
    service = TestBed.inject(ExpenseService);
    httpTestingController = TestBed.inject(HttpTestingController);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });
  
  // Check if ExpenseService is created
  fit('ExpenseService_should_have_expenseservice', () => {
    expect(service).toBeTruthy();
  });

  // Check if ExpenseService has getExpenses method
  fit('ExpenseService_should_have_getExpenses_method', () => {
    expect(service['getExpenses']).toBeTruthy();
  });

  // Check if ExpenseService has addExpense method
  fit('ExpenseService_should_have_addExpense_method', () => {
    expect(service['addExpense']).toBeTruthy();
  });

  // Check if ExpenseService has addExpense method that returns an array of expenses
  fit('ExpenseService_should add an expense and return it', () => {
    const mockExpense = {
      expenseDetails: 'Test expense',
      category: 'Test category',
      amount: 100,
      paymentMode: 'Cash',
      expenseDate: '2022-01-01'
    };
  
    service['addExpense'](mockExpense).subscribe((expense) => {
      expect(expense).toEqual(mockExpense);
    });
  
    const req = httpTestingController.expectOne(`${service['apiUrl']}api/expense`);
    expect(req.request.method).toBe('POST');
    req.flush(mockExpense);
  });

  fit('expenseService_should_get_expenses', () => {
    const mockExpenses = [
      {
        expenseDetails: 'Test expense 1',
        category: 'Test category',
        amount: 100,
        paymentMode: 'Cash',
        expenseDate: '2022-01-01'
      },
      {
        expenseDetails: 'Test expense 2',
        category: 'Test category',
        amount: 200,
        paymentMode: 'Card',
        expenseDate: '2022-01-02'
      }
    ];
  
    service['getExpenses']().subscribe((expenses) => {
      expect(expenses).toEqual(mockExpenses);
    });
  
    const req = httpTestingController.expectOne(`${service['apiUrl']}api/expense`);
    expect(req.request.method).toBe('GET');
    req.flush(mockExpenses);
  });
});