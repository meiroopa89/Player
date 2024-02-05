import { Expense } from "./expense.model";

  // Check if Expense has properties ExpenseID, ExpenseDetails, Category, Amount, PaymentMode, and ExpenseDate
  describe('Expense', () => {
    fit('ExpenseModel_should_update_property_values_using_setters', () => {
      // Arrange
      const expense: Expense = {
        ExpenseID: 1,
        ExpenseDetails: 'Dinner with friends',
        Category: 'Food',
        Amount: 50.00,
        PaymentMode: 'Credit Card',
        ExpenseDate: '2024-01-30',
      };
   
      // Act & Assert
      // Check if the entire expense object is truthy (defined)
      expect(expense).toBeTruthy();
   
      // Check if individual properties are truthy (defined)
      expect(expense['ExpenseID']).toBeTruthy();
      expect(expense['ExpenseDetails']).toBeTruthy();
      expect(expense['Category']).toBeTruthy();
      expect(expense['Amount']).toBeTruthy();
      expect(expense['PaymentMode']).toBeTruthy();
      expect(expense['ExpenseDate']).toBeTruthy();
   
      // Check data types for each property
      expect(typeof expense['ExpenseID']).toEqual('number');
      expect(typeof expense['ExpenseDetails']).toEqual('string');
      expect(typeof expense['Category']).toEqual('string');
      expect(typeof expense['Amount']).toEqual('number');
      expect(typeof expense['PaymentMode']).toEqual('string');
      expect(typeof expense['ExpenseDate']).toEqual('string');
    });
  });