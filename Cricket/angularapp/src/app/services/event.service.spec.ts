import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { EventService } from './event.service';

describe('EventService', () => {
  let service: EventService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EventService]
    });

    service = TestBed.inject(EventService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  fit('should add an event', () => {
    const eventData = { /* your event data here */ };

    service.addEvent(eventData).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/event`);
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(eventData);

    req.flush({}); // You can modify the response as needed
  });

  fit('should get all events', () => {
    service.getAllEvents().subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/event`);
    expect(req.request.method).toBe('GET');

    req.flush({}); // You can modify the response as needed
  });

  fit('should get an event by id', () => {
    const eventId = '123';

    service.getEventById(eventId).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/event/${eventId}`);
    expect(req.request.method).toBe('GET');

    req.flush({}); // You can modify the response as needed
  });

  // Add more test cases as needed
});
