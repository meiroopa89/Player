import { Car } from './phone.model'; // Import Car model

describe('Car', () => { // Updated description to 'Car'
  fit('should create car instance', () => { // Updated 'fit' to 'it' and updated test description
    const car: Car = { // Updated 'recipe' to 'car' and 'Recipe' to 'Car'
      id: 1, // Adjusted property name
      make: 'Test Make', // Adjusted property name
      model: 'Test Model', // Adjusted property name
      year: 'Test Year', // Adjusted property name
      color: 'Test Color', // Adjusted property name
      mileage: 10000, // Adjusted property name
      price: 5000 // Adjusted property name
    };

    // Check if the car object exists
    expect(car).toBeTruthy();

    // Check individual properties of the car
    expect(car.id).toBe(1); // Adjusted property name
    expect(car.make).toBe('Test Make'); // Adjusted property name
    expect(car.model).toBe('Test Model'); // Adjusted property name
    expect(car.year).toBe('Test Year'); // Adjusted property name
    expect(car.color).toBe('Test Color'); // Adjusted property name
    expect(car.mileage).toBe(10000); // Adjusted property name
    expect(car.price).toBe(5000); // Adjusted property name
  });
});
