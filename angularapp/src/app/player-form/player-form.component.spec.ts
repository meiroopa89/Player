import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { PlayerService } from '../services/player.service'; // Adjusted service name
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';
import { Player } from '../models/player.model'; // Adjusted model name
import { PlayerFormComponent } from './player-form.component'; // Adjusted component name

describe('PlayerFormComponent', () => { // Adjusted component name
  let component: PlayerFormComponent; // Adjusted component name
  let fixture: ComponentFixture<PlayerFormComponent>; // Adjusted component name
  let playerService: PlayerService; // Adjusted service name
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PlayerFormComponent], // Adjusted component name
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
      providers: [PlayerService] // Adjusted service name
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayerFormComponent); // Adjusted component name
    component = fixture.componentInstance; // Adjusted component name
    playerService = TestBed.inject(PlayerService); // Adjusted service name
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

 fit('should create PlayerFormComponent', () => { // Adjusted component name
    expect(component).toBeTruthy();
  });

  fit('PlayerFormComponent_should_render_error_messages_when_required_fields_are_empty_on_submit', () => { // Adjusted component name
    // Set all fields to empty strings
    component.newPlayer = {
      playerId: null,
      name: '',
      position: '',
      number: null,
      age: null,
      nationality: ''
    } as Player;
    
    // Manually trigger form submission
    component.formSubmitted = true;
    
    fixture.detectChanges();
    
    // Find the form element
    const form = fixture.debugElement.query(By.css('form')).nativeElement;
    
    // Submit the form
    form.dispatchEvent(new Event('submit'));
    
    fixture.detectChanges();
    
    // Check if error messages are rendered for each field
    expect(fixture.debugElement.query(By.css('#name + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#position + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#number + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#age + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#nationality + .error-message'))).toBeTruthy();
  });

  fit('PlayerFormComponent_should_call_addPlayer_method_while_adding_the_player', () => { // Adjusted component name and method name
    // Create a mock Player object with all required properties
    const player: Player = { 
      playerId: 1, 
      name: 'John Doe', 
      position: 'Forward', 
      number: 10, 
      age: 25, 
      nationality: 'American'
    };
    
    const addPlayerSpy = spyOn(component, 'addPlayer').and.callThrough(); // Adjusted method name
    component.addPlayer(); // Adjusted method name
    expect(addPlayerSpy).toHaveBeenCalled();
  });
});
