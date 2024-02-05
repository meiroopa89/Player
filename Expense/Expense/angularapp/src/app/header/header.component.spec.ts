import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { HeaderComponent } from './header.component';

describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let fixture: ComponentFixture<HeaderComponent>;
  let router: Router;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HeaderComponent],
      imports: [RouterTestingModule],
    }).compileComponents();

    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    router = TestBed.inject(Router);
  });

  // Check if HeaderComponent is created  
  fit('should create HeaderComponent', () => {
    expect(component).toBeTruthy();
  });

  // Check if HeaderComponent has a navbar
  fit('should navigate to Add New Expense', () => {
    spyOn(router, 'navigate');
    const addExpenseLink = fixture.debugElement.query(By.css('.nav-link:first-child'));

    addExpenseLink.triggerEventHandler('click', null);

    expect(router.navigate).toHaveBeenCalledWith(['/addNewExpense']);
  });

// Check if HeaderComponent has a brand name ExpenseManager
  fit('should have ExpenseManager as the brand', () => {
    const brandElement: HTMLElement = fixture.nativeElement.querySelector('.navbar-brand');
    expect(brandElement.textContent).toContain('ExpenseManager');
  });

  // Check if HeaderComponent has a link with text Add New Expense
  fit('should have a link with text View Expenses', () => {
    const navItems: NodeListOf<HTMLElement> = fixture.nativeElement.querySelectorAll('.nav-link');
    const viewExpensesLink: HTMLElement = navItems[navItems.length - 1];
    expect(viewExpensesLink.textContent).toContain('View Expenses');
  });

});
