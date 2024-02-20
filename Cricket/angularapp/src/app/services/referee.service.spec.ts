import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { RefereeService } from './referee.service';

describe('RefereeService', () => {
  let service: RefereeService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [RefereeService]
    });

    service = TestBed.inject(RefereeService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should add a referee', () => {
    const refereeData = {
      RefereeID: 1,
      userId: 123,
      subject: 'Referee Subject',
      body: 'Referee Body',
      rating: 5,
      dateCreated: new Date(),
      // Other properties of the referee
    };

    service.addReferee(refereeData).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/referee`);
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(refereeData);

    req.flush({}); // You can modify the response as needed
  });

  it('should update a referee', () => {
    const refereeData = {
      RefereeID: 1,
      userId: 123,
      subject: 'Referee Subject',
      body: 'Referee Body',
      rating: 5,
      dateCreated: new Date(),
      // Other properties of the referee
    };

    service.updateReferee(refereeData).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/referee/1`);
    expect(req.request.method).toBe('PUT');
    expect(req.request.body).toEqual(refereeData);

    req.flush({}); // You can modify the response as needed
  });

  it('should delete a referee', () => {
    const refereeData = {
      RefereeID: 1,
      userId: 123,
      subject: 'Referee Subject',
      body: 'Referee Body',
      rating: 5,
      dateCreated: new Date(),
      // Other properties of the referee
    };

    service.deleteReferee(refereeData).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/referee/1`);
    expect(req.request.method).toBe('DELETE');

    req.flush({}); 
  });

  it('should get a referee by ID', () => {
    const refereeId = '1';

    service.getRefereeById(refereeId).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/referee/1`);
    expect(req.request.method).toBe('GET');

    req.flush({});
  });

  it('should get all referees', () => {
    service.getAllReferees().subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/referee`);
    expect(req.request.method).toBe('GET');

    req.flush({});
  });

});
