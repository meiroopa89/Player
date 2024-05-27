import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PlayerService } from '../services/player.service'; // Adjusted service name
import { Player } from '../models/player.model'; // Adjusted model name

@Component({
  selector: 'app-player-list', // Adjusted selector
  templateUrl: './player-list.component.html', // Adjusted template URL
  styleUrls: ['./player-list.component.css'] // Adjusted style URL
})
export class PlayerListComponent implements OnInit {
  players: Player[] = []; // Adjusted property name

  constructor(private playerService: PlayerService, private router: Router) { } // Adjusted service name

  ngOnInit(): void {
    this.loadPlayers(); // Adjusted method name
  }

  loadPlayers(): void { // Adjusted method name
    this.playerService.getPlayers().subscribe(players => { // Adjusted method name
      this.players = players;
      console.log(this.players);
    });
  }

  deletePlayer(playerId: number): void { // Adjusted method name and parameter
    // Navigate to confirm delete page with the player ID as a parameter
    this.router.navigate(['/confirmDelete', playerId]);
  }
}
