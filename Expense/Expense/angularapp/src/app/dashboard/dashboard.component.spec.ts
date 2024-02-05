// dashboard.component.spec.ts
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed, async } from '@angular/core/testing';

import { ExpenseService } from '../services/expense.service';
import { DashboardComponent } from './dashboard.component';

describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;
  let expenseService: ExpenseService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [DashboardComponent],
      providers: [ExpenseService]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    expenseService = TestBed.inject(ExpenseService);
  });

  // Check if DashboardComponent is created
  fit('should create DashboardComponent', () => {
    expect(component).toBeTruthy();
  });

  // Check if DashboardComponent has a table for displaying expenses
    fit('should call loadExpenses on ngOnInit', () => {
      spyOn(component, 'loadExpenses');
      component.ngOnInit();
      expect(component['loadExpenses']).toHaveBeenCalled();
    });

    // Check if table headers are correctly displayed
  fit('should display table headers', () => {
    fixture.detectChanges();

    const compiled = fixture.debugElement.nativeElement as HTMLElement; // Type assertion
    const tableHeaders = Array.from(compiled.querySelectorAll('th')).map(th => th.textContent.trim());

    expect(tableHeaders).toEqual(['Expense Details', 'Category', 'Amount', 'Payment Mode', 'Expense Date']);
  });
});