import { Component } from '@angular/core';
import { Player } from '../models/player.model';
import { Router } from '@angular/router';
import { PlayerService } from '../services/player.service'; // Updated service import

@Component({
  selector: 'app-player-form', // Updated component selector
  templateUrl: './player-form.component.html', // Updated template URL
  styleUrls: ['./player-form.component.css'] // Updated style URLs
})
export class PlayerFormComponent { // Updated component class name
  newPlayer: Player = { // Updated object initialization to Player
    playerId: 0,
    name: '',
    position: '',
    number: 0,
    age: 0,
    nationality: ''
  };

  formSubmitted = false;

  constructor(private playerService: PlayerService, private router: Router) { } // Updated service injection

  addPlayer(): void { // Updated method name
    this.formSubmitted = true;
    if (this.isFormValid()) {
      this.playerService.addPlayer(this.newPlayer).subscribe(() => { // Updated service method call
        console.log('Player added successfully!'); // Updated success message
        this.router.navigate(['/viewPlayers']); // Updated navigation path
      });
    }
  }
  
  isFieldInvalid(fieldName: string): boolean { // Updated method name
    const fieldValue = this.newPlayer[fieldName as keyof Player];
    return !fieldValue && this.formSubmitted;
  }

  isFormValid(): boolean { // Updated method name
    return !this.isFieldInvalid('name') && !this.isFieldInvalid('position') &&
      !this.isFieldInvalid('number') && !this.isFieldInvalid('age') &&
      !this.isFieldInvalid('nationality');
  }
}
