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

  // fit('Frontend_should_call_the_API_and_add_an_event', () => {
  //   const eventData = 
  //   { 
  //   eventId: 1,
  //   eventName: 'eventname',
  //   startDate: '1997-01-1',
  //   endDate: '1997-01-2',
  //   eventImageURL: 'image url',
  //   description: 'description'
  //   }

  //   service.addEvent(eventData).subscribe();

  //   const req = httpMock.expectOne(`${service.apiUrl}/api/event`);
  //   expect(req.request.method).toBe('POST');
  //   expect(req.request.body).toEqual(eventData);

  //   req.flush({});
  // });

  fit('Frontend_should_call_the_API_and_get_all_events', () => {
    service.getAllEvents().subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/event`);
    expect(req.request.method).toBe('GET');

    req.flush({}); 
  });

  // fit('Frontend_should_call_the_API_and__get_an_event_by_id', () => {
  //   const eventId = '123';

  //   service.getEventById(eventId).subscribe();

  //   const req = httpMock.expectOne(`${service.apiUrl}/api/event/${eventId}`);
  //   expect(req.request.method).toBe('GET');

  //   req.flush({}); 
  // });
});
