import { Component, OnInit } from '@angular/core';
import { PlayerService } from './services/player.service';
import { Player } from './models/player.model';

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.css']
})
export class PlayerListComponent implements OnInit {
  players: Player[] = [];

  constructor(private playerService: PlayerService) { }

  ngOnInit(): void {
    this.getPlayers();
  }

  getPlayers(): void {
    this.playerService.getPlayers().subscribe(players => this.players = players);
  }

  addPlayer(newPlayer: Player): void {
    this.playerService.addPlayer(newPlayer).subscribe(player => this.players.push(player));
  }

  deletePlayer(playerId: number): void {
    this.playerService.deletePlayer(playerId).subscribe(() => {
      this.players = this.players.filter(player => player.playerId !== playerId);
    });
  }

  getPlayer(playerId: number): void {
    this.playerService.getPlayer(playerId).subscribe(player => {
      // Handle retrieved player
      console.log(player);
    });
  }
}
