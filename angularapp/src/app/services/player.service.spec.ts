import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Player } from '../models/player.model'; // Adjusted import
import { PlayerService } from './player.service'; // Adjusted import

describe('PlayerService', () => { // Changed description to PlayerService
  let service: PlayerService; // Changed service variable name to PlayerService
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [PlayerService], // Changed service provider to PlayerService
    });
    service = TestBed.inject(PlayerService); // Changed service variable assignment to PlayerService
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('should_creat_PlayerService', () => { // Changed fit to it and updated test description
    expect(service).toBeTruthy();
  });

  fit('should_add_a_Player_and_return_it', () => { // Changed fit to it and updated test description
    const mockPlayer: Player = {
      playerId: 1,
      name: 'Lionel Messi',
      position: 'Forward',
      number: 10,
      age: 34,
      nationality: 'Argentinian'
    };

    service.addPlayer(mockPlayer).subscribe((player) => { // Changed addBook to addPlayer and adjusted callback parameter
      expect(player).toEqual(mockPlayer);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Player`); // Adjusted API endpoint
    expect(req.request.method).toBe('POST');
    req.flush(mockPlayer);
  });

  fit('should_get_Players', () => { // Changed fit to it and updated test description
    const mockPlayers: Player[] = [
      {
        playerId: 1,
        name: 'Lionel Messi',
        position: 'Forward',
        number: 10,
        age: 34,
        nationality: 'Argentinian'
      }
    ];

    service.getPlayers().subscribe((players) => { // Changed getBooks to getPlayers and adjusted callback parameter
      expect(players).toEqual(mockPlayers);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Player`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockPlayers);
  });

  fit('should_delete_a_Player', () => { // Changed fit to it and updated test description
    const playerId = 100;

    service.deletePlayer(playerId).subscribe(() => {
      expect().nothing();
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Player/${playerId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });

  fit('should_get_a_Player_by_id', () => { // Changed fit to it and updated test description
    const playerId = 100;
    const mockPlayer: Player = {
      playerId: playerId,
      name: 'Lionel Messi',
      position: 'Forward',
      number: 10,
      age: 34,
      nationality: 'Argentinian'
    };

    service.getPlayer(playerId).subscribe((player) => { // Changed getBook to getPlayer and adjusted callback parameter
      expect(player).toEqual(mockPlayer);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Player/${playerId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockPlayer);
  });
});
