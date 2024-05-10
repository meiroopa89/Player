import { Car } from './car.model'; // Import Car model

describe('Car', () => { // Change description to car
  fit('Models should create car instance', () => { // Change fit to it and update test description
    const car: Car = { // Change recipe to car and Recipe to car
      id: 1, // Adjust property name
      firstName: 'Test First Name', // Adjust property name
      lastName: 'Test Last Name', // Adjust property name
      specialization: 'Test Specialization', // Adjust property name
      phoneNumber: 'Test Phone Number', // Adjust property name
      email: 'test@email.com', // Adjust property name
      address: 'Test Address' // Adjust property name
    } as any;

    // Check if the car object exists
    expect(car).toBeTruthy();

    // Check individual properties of the car
    expect(car.id).toBe(1); // Adjust property name
    expect(car.firstName).toBe('Test First Name'); // Adjust property name
    expect(car.lastName).toBe('Test Last Name'); // Adjust property name
    expect(car.specialization).toBe('Test Specialization'); // Adjust property name
    expect(car.phoneNumber).toBe('Test Phone Number'); // Adjust property name
    expect(car.email).toBe('test@email.com'); // Adjust property name
    expect(car.address).toBe('Test Address'); // Adjust property name
  });
});
