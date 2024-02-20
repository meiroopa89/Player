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


  fit('should add a player', () => {
    const playerData = {
      playerId: '1',
      playerName: 'John Doe',
      age: '25',
      country: 'USA',
      battingStyle: 'Right-handed',
      bowlingStyle: 'Medium',
      dateOfBirth: '1997-01-15',
      role: 'Batsman',
      totalMatchesPlayed: '50',
      totalRunsScored: '2000',
      totalWicketsTaken: '5',
      totalCatches: '20',
    };

    service.addPlayer(playerData).subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/player`);
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual(playerData);

    req.flush({}); // You can modify the response as needed
  });

  fit('should get all players', () => {
    service.getAllPlayers().subscribe();

    const req = httpMock.expectOne(`${service.apiUrl}/api/player`);
    expect(req.request.method).toBe('GET');

    req.flush({}); // You can modify the response as needed
  });

});
