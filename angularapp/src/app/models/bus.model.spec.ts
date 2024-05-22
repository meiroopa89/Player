import { Bus } from './bus.model'; // Import Bus model

describe('Bus', () => { // Updated description to 'Bus'
  fit('should_create_bus_instance', () => { // Updated test description
    const bus: Bus = { // Updated 'flight' to 'bus' and 'Flight' to 'Bus'
      bookingId: 1, // Adjusted property name
      busNumber: 'Test Bus Number', // Adjusted property name
      routeSource: 'Test Route Source', // Adjusted property name
      routeDestination: 'Test Route Destination', // Adjusted property name
      passengerName: 'Test Passenger Name', // Adjusted property name
      bookingDate: '2024-05-15' // Adjusted property name and added a string date
    } as any;

    // Check if the bus object exists
    expect(bus).toBeTruthy();

    // Check individual properties of the bus
    expect(bus.bookingId).toBe(1); // Adjusted property name
    expect(bus.busNumber).toBe('Test Bus Number'); // Adjusted property name
    expect(bus.routeSource).toBe('Test Route Source'); // Adjusted property name
    expect(bus.routeDestination).toBe('Test Route Destination'); // Adjusted property name
    expect(bus.passengerName).toBe('Test Passenger Name'); // Adjusted property name
    expect(bus.bookingDate).toBe('2024-05-15'); // Adjusted property name
  });
});
