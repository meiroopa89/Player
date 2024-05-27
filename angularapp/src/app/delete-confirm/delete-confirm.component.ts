import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Player } from '../models/player.model'; // Adjusted model name
import { PlayerService } from '../services/player.service'; // Adjusted service name

@Component({
  selector: 'app-delete-confirm', // Component selector
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  playerId: number;
  player: Player = {} as Player; // Initialize player property with an empty object

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private playerService: PlayerService // Adjusted service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.playerId = +params['id']; // Adjust parameter name
      this.playerService.getPlayer(this.playerId).subscribe(
        (player: Player) => { // Adjust type casting
          this.player = player;
        },
        error => {
          console.error('Error fetching player:', error);
        }
      );
    });
  }

  confirmDelete(playerId: number): void { // Adjust method signature
    this.playerService.deletePlayer(playerId).subscribe(
      () => {
        console.log('Player deleted successfully.');
        this.router.navigate(['/viewPlayers']); // Adjust the route
      },
      (error) => {
        console.error('Error deleting player:', error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/viewPlayers']); // Adjust the route
  }
}
