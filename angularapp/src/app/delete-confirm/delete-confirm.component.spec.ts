import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { DeleteConfirmComponent } from './delete-confirm.component';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FlightService } from '../services/bus.service'; // Adjusted service name

describe('DeleteConfirmComponent', () => {
    let component: DeleteConfirmComponent;
    let fixture: ComponentFixture<DeleteConfirmComponent>;
    let router: Router;
    let activatedRoute: ActivatedRoute;
    let mockFlightService: jasmine.SpyObj<FlightService>; // Adjusted service name

    beforeEach(waitForAsync(() => {
        mockFlightService = jasmine.createSpyObj<FlightService>('FlightService', ['getFlight', 'deleteFlight'] as any); // Adjusted service name and methods

        TestBed.configureTestingModule({
            imports: [RouterTestingModule, HttpClientModule, FormsModule, HttpClientTestingModule],
            declarations: [DeleteConfirmComponent],
            providers: [
                { provide: FlightService, useValue: mockFlightService } // Adjusted service name
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

    fit('DeleteConfirmComponent_should_call_deleteFlight_method_when_confirmDelete_is_called', () => {
        const flightId = 1; // Adjusted ID name
        
        mockFlightService['deleteFlight'].and.returnValue(of(null)); // Adjusted method name

        component['confirmDelete'](flightId); // Adjusted parameter name

        expect(mockFlightService['deleteFlight']).toHaveBeenCalledWith(flightId); // Adjusted method name and parameter
    });
});
