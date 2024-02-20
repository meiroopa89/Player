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

  fit('Frontend_should_call_the_API_and_add_a_referee', () => {
    const refereeData = {
      RefereeName: 'Refereename',
      NoOfMatches: 5,
      RefereeImageURL: 'Image url',
    };

    service.addReferee(refereeData).subscribe();
    const response = { RefereeID: 1, ...refereeData};

    const req = httpMock.expectOne(`${service.apiUrl}/api/referee`);
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(refereeData);

    req.flush(response);
  });


  // fit('Frontend_should_call_the_API_and_delete_a_referee', () => {
  //   const RefereeID = 1;
  
  //   service.deleteReferee(RefereeID).subscribe();
  
  //   const req = httpMock.expectOne(`${service.apiUrl}/api/player/${RefereeID}`);
  //   expect(req.request.method).toBe('DELETE');
  //   // expect(req.request.headers.get('Authorization')).toBeTruthy();
  //   req.flush({}); 
  // });

  fit('Frontend_should_call_the_API_and_get_all_referees', () => {
    service.getAllReferees().subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/referee`);
    expect(req.request.method).toBe('GET');

    req.flush({});
  });


});
