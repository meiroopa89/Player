import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { PlayerService } from './player.service';

describe('PlayerService', () => {
  let service: PlayerService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [PlayerService]
    });

    service = TestBed.inject(PlayerService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });


  fit('Frontend_should_call_the_API_and_add_a_player', () => {
    const playerData = {
      playerId: 1,
      playerName: 'John Doe',
      Age: 25,
      Country: 'USA',
      BattingStyle: 'Right-handed',
      BowlingStyle: 'Medium',
      DateOfBirth: '1997-01-15',
      Role: 'Batsman',
      TotalMatchesPlayed: 50,
      TotalRunsScored: 2000,
      TotalWicketsTaken: 5,
      TotalCatches: 20,
    };

    service.addPlayer(playerData).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/player`);
    expect(req.request.method).toBe('POST');
    expect(req.request.headers.get('Authorization')).toBeTruthy();
    expect(req.request.body).toEqual(playerData);

    req.flush({}); 
  });

  fit('Frontend_should_call_the_API_and_get_all_players', () => {
    service.getAllPlayers().subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/player`);
    expect(req.request.method).toBe('GET');
    expect(req.request.headers.get('Authorization')).toBeTruthy();
    req.flush({}); 
  });

  fit('Frontend_should_call_the_API_and_delete_a_player', () => {
    const PlayerId = 1;
  
    service.deletePlayer(PlayerId).subscribe();
  
    const req = httpMock.expectOne(`${service.apiUrl}/api/player/${PlayerId}`);
    expect(req.request.method).toBe('DELETE');
    expect(req.request.headers.get('Authorization')).toBeTruthy();
    req.flush({}); 
  });
  

});