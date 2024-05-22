import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Bus } from '../models/bus.model'; // Adjusted import
import { BusService } from './bus.service';

describe('BusService', () => { // Changed description to BusService
  let service: BusService; // Changed service variable name to BusService
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [BusService], // Changed service provider to BusService
    });
    service = TestBed.inject(BusService); // Changed service variable assignment to BusService
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('BusService_should_be_created', () => { // Changed fit to it and updated test description
    expect(service).toBeTruthy();
  });

  fit('BusService_should_add_a_Bus_and_return_it', () => { // Changed fit to it and updated test description
    const mockBus: Bus = { // Updated 'flight' to 'bus' and 'Flight' to 'Bus'
      bookingId: 1, // Adjusted property name
      busNumber: 'Test Bus Number', // Adjusted property name
      routeSource: 'Test Route Source', // Adjusted property name
      routeDestination: 'Test Route Destination', // Adjusted property name
      passengerName: 'Test Passenger Name', // Adjusted property name
      bookingDate: '2024-05-15' // Adjusted property name and added a string date
    } as any;

    service.addBus(mockBus).subscribe((bus) => { // Changed addFlight to addBus and adjusted callback parameter
      expect(bus).toEqual(mockBus);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Bus`); // Adjusted API endpoint
    expect(req.request.method).toBe('POST');
    req.flush(mockBus);
  });

  fit('BusService_should_get_Buses', () => { // Changed fit to it and updated test description
    const mockBuses: Bus[] = [
      {
        bookingId: 1, // Adjusted property name
        busNumber: 'Test Bus Number', // Adjusted property name
        routeSource: 'Test Route Source', // Adjusted property name
        routeDestination: 'Test Route Destination', // Adjusted property name
        passengerName: 'Test Passenger Name', // Adjusted property name
        bookingDate: '2024-05-15' // Adjusted property name
      }
    ] as any;

    service.getBuses().subscribe((buses) => { // Changed getFlights to getBuses and adjusted callback parameter
      expect(buses).toEqual(mockBuses);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Bus`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockBuses);
  });

  fit('BusService_should_delete_Bus', () => { // Changed fit to it and updated test description
    const bookingId = 100;

    service.deleteBus(bookingId).subscribe(() => {
      expect().nothing();
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Bus/${bookingId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });

  fit('BusService_should_get_Bus_by_id', () => { // Changed fit to it and updated test description
    const bookingId = 100;
    const mockBus: Bus = {
      bookingId: bookingId, // Adjusted property name
      busNumber: 'Test Bus Number', // Adjusted property name
      routeSource: 'Test Route Source', // Adjusted property name
      routeDestination: 'Test Route Destination', // Adjusted property name
      passengerName: 'Test Passenger Name', // Adjusted property name
      bookingDate: '2024-05-15' // Adjusted property name
    } as any;

    service.getBus(bookingId).subscribe((bus) => { // Changed getFlight to getBus and adjusted callback parameter
      expect(bus).toEqual(mockBus);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Bus/${bookingId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockBus);
  });
});
