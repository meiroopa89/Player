import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { DeleteConfirmComponent } from './delete-confirm.component';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { PlayerService } from '../services/player.service'; // Adjusted service name

describe('DeleteConfirmComponent', () => {
    let component: DeleteConfirmComponent;
    let fixture: ComponentFixture<DeleteConfirmComponent>;
    let router: Router;
    let activatedRoute: ActivatedRoute;
    let mockPlayerService: jasmine.SpyObj<PlayerService>; // Adjusted service name

    beforeEach(waitForAsync(() => {
        mockPlayerService = jasmine.createSpyObj<PlayerService>('PlayerService', ['getPlayer', 'deletePlayer']); // Adjusted service name and methods

        TestBed.configureTestingModule({
            imports: [RouterTestingModule, HttpClientModule, FormsModule, HttpClientTestingModule],
            declarations: [DeleteConfirmComponent],
            providers: [
                { provide: PlayerService, useValue: mockPlayerService } // Adjusted service name
            ]
        }).compileComponents();
        router = TestBed.inject(Router);
        activatedRoute = TestBed.inject(ActivatedRoute);
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(DeleteConfirmComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    fit('should_create_DeleteConfirmComponent', () => {
        expect(component).toBeTruthy();
    });

    fit('should_call_deletePlayer_method_when_confirmDelete_is_called', () => {
        const playerId = 1; // Adjusted ID name

        mockPlayerService.deletePlayer.and.returnValue(of(null)); // Adjusted method name

        component.confirmDelete(playerId); // Adjusted parameter name

        expect(mockPlayerService.deletePlayer).toHaveBeenCalledWith(playerId); // Adjusted method name and parameter
    });
});
