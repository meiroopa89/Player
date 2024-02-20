import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { VenueService } from './venue.service';
import { apiUrl } from 'src/api.config';

describe('VenueService', () => {
  let service: VenueService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [VenueService]
    });

    service = TestBed.inject(VenueService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  fit('Frontend_should_call_the_API_and_get_all_venues', () => {``
    service.getAllVenues().subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/venue`);
    expect(req.request.method).toBe('GET');
    expect(req.request.headers.get('Authorization')).toBeTruthy();
    req.flush({});
  });

  fit('Frontend_should_call_the_API_and_add_a_venue', () => {
    const venueData = {
      VenueName: 'Test Venue',
      VenueImageURL: 'test-image-url',
      VenueDescription: 'Test Description',
      VenueLocation: 'Test Location',
    };
    const response = { VenueId: 1, ...venueData };

    service.addVenue(venueData).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/venue`);
    expect(req.request.method).toBe('POST');
    expect(req.request.headers.get('Authorization')).toBeTruthy();
    expect(req.request.body).toEqual(venueData);

    req.flush(response);
  });

});
