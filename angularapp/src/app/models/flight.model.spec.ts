import { Flight } from './flight.model'; // Import Flight model

describe('Flight', () => { // Updated description to 'Flight'
  fit('should_create_flight_instance', () => { // Updated 'fit' to 'it' and updated test description
    const flight: Flight = { // Updated 'recipe' to 'flight' and 'Recipe' to 'Flight'
      flightId: 1, // Adjusted property name
      name: 'Test Airline', // Adjusted property name
      departureAirport: 'Test Departure Airport', // Adjusted property name
      destinationAirport: 'Test Destination Airport', // Adjusted property name
      departureDate: new Date('2024-05-15'), // Adjusted property name and added a date
      arrivalDate: new Date('2024-05-16') // Adjusted property name and added a date
    };

    // Check if the flight object exists
    expect(flight).toBeTruthy();

    // Check individual properties of the flight
    expect(flight.flightId).toBe(1); // Adjusted property name
    expect(flight.name).toBe('Test Airline'); // Adjusted property name
    expect(flight.departureAirport).toBe('Test Departure Airport'); // Adjusted property name
    expect(flight.destinationAirport).toBe('Test Destination Airport'); // Adjusted property name
    expect(flight.departureDate).toEqual(new Date('2024-05-15')); // Adjusted property name and date comparison
    expect(flight.arrivalDate).toEqual(new Date('2024-05-16')); // Adjusted property name and date comparison
  });
});
