import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { PlayerListComponent } from './player-list.component'; // Adjusted component name
import { PlayerService } from '../services/player.service'; // Adjusted service name
import { of } from 'rxjs';
import { Player } from '../models/player.model'; // Adjusted model name

describe('PlayerListComponent', () => { // Adjusted component name
    let component: PlayerListComponent; // Adjusted component name
    let fixture: ComponentFixture<PlayerListComponent>; // Adjusted component name
    let mockPlayerService: jasmine.SpyObj<PlayerService>; // Specify the type of mock

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockPlayerService = jasmine.createSpyObj<PlayerService>('PlayerService', ['getPlayers', 'deletePlayer'] as any); // Adjusted service name

        TestBed.configureTestingModule({
            declarations: [PlayerListComponent], // Adjusted component name
            imports: [RouterTestingModule, HttpClientTestingModule],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: PlayerService, useValue: mockPlayerService } // Adjusted service name
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(PlayerListComponent); // Adjusted component name
        component = fixture.componentInstance; // Adjusted component name
    });

    fit('should_create_PlayerListComponent', () => { // Adjusted function name and component name
        expect(component).toBeTruthy();
    });

    fit('PlayerListComponent_should_call_loadPlayers_on_ngOnInit', () => { // Adjusted function name and method name
        spyOn(component, 'loadPlayers'); // Adjusted method name
        fixture.detectChanges();
        expect(component.loadPlayers).toHaveBeenCalled(); // Adjusted method name
    });

});
