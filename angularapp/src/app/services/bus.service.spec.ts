import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Flight } from '../models/bus.model'; // Adjusted import
import { FlightService } from './bus.service';

describe('FlightService', () => { // Changed description to FlightService
  let service: FlightService; // Changed service variable name to FlightService
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [FlightService], // Changed service provider to FlightService
    });
    service = TestBed.inject(FlightService); // Changed service variable assignment to FlightService
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('FlightService_should_be_created', () => { // Changed fit to it
    expect(service).toBeTruthy();
  });

  fit('FlightService_should_add_a_Flight_and_return_it', () => { // Changed fit to it
    const mockFlight: Flight = { // Updated 'recipe' to 'flight' and 'Recipe' to 'Flight'
      flightId: 1, // Adjusted property name
      name: 'Test Name', // Adjusted property name
      departureAirport: 'Test Departure Airport', // Adjusted property name
      destinationAirport: 'Test Destination Airport', // Adjusted property name
      departureDate: new Date(), // Adjusted property name and initialized with current date
      arrivalDate: new Date() // Adjusted property name and initialized with current date
    } as any;

    service['addFlight'](mockFlight).subscribe((flight) => { // Adjusted callback parameter
      expect(flight).toEqual(mockFlight);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Flight`); // Adjusted API endpoint
    expect(req.request.method).toBe('POST');
    req.flush(mockFlight);
  });

  fit('FlightService_should_get_Flights', () => { // Changed fit to it
    const mockFlights: Flight[] = [
      {
        flightId: 1, // Adjusted property name
        name: 'Test Name', // Adjusted property name
        departureAirport: 'Test Departure Airport', // Adjusted property name
        destinationAirport: 'Test Destination Airport', // Adjusted property name
        departureDate: new Date(), // Adjusted property name and initialized with current date
        arrivalDate: new Date() // Adjusted property name and initialized with current date
      }
    ] as any;

    service['getFlights']().subscribe((flights) => { // Adjusted callback parameter
      expect(flights).toEqual(mockFlights);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Flight`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockFlights);
  });

  fit('FlightService_should_delete_Flight', () => { // Changed fit to it
    const flightId = 100;

    service['deleteFlight'](flightId).subscribe(() => {
      expect().nothing();
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Flight/${flightId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });

  fit('FlightService_should_get_Flight_by_id', () => { // Changed fit to it
    const flightId = 100;
    const mockFlight: Flight = {
      flightId: flightId, // Adjusted property name
      name: 'Test Name', // Adjusted property name
      departureAirport: 'Test Departure Airport', // Adjusted property name
      destinationAirport: 'Test Destination Airport', // Adjusted property name
      departureDate: new Date(), // Adjusted property name and initialized with current date
      arrivalDate: new Date() // Adjusted property name and initialized with current date
    } as any;

    service['getFlight'](flightId).subscribe((flight) => { // Adjusted callback parameter
      expect(flight).toEqual(mockFlight);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Flight/${flightId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockFlight);
  });
});
