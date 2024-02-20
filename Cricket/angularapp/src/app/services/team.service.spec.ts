import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TeamService } from './team.service';

describe('TeamService', () => {
  let service: TeamService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TeamService]
    });

    service = TestBed.inject(TeamService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  fit('Frontend_should_call_the_API_and_add_a_team', () => {
    const teamData = {
      TeamName: 'Test Team',
      TeamImageURL: 'test-image-url',
      TeamDescription: 'Test description',
    };
    const response = { TeamId: 1, ...teamData };

    service.addTeam(teamData).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/team`);
    expect(req.request.method).toBe('POST');
    // expect(req.request.headers.get('Authorization')).toBeTruthy();
    expect(req.request.body).toEqual(teamData);

    req.flush(response);
  });

  fit('Frontend_should_call_the_API_and_get_all_teams', () => {
    service.getAllTeams().subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/team`);
    expect(req.request.method).toBe('GET');
    // expect(req.request.headers.get('Authorization')).toBeTruthy();
    req.flush({}); 
  });
});
