import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FlightListComponent } from './flight-list.component'; // Adjusted component name
import { FlightService } from '../services/flight.service'; // Adjusted service name

describe('FlightListComponent', () => { // Adjusted component name
    let component: FlightListComponent; // Adjusted component name
    let fixture: ComponentFixture<FlightListComponent>; // Adjusted component name
    let mockFlightService: jasmine.SpyObj<FlightService>; // Specify the type of mock

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockFlightService = jasmine.createSpyObj<FlightService>('FlightService', ['getFlights', 'deleteFlight'] as any); // Adjusted service name

        TestBed.configureTestingModule({
            declarations: [FlightListComponent], // Adjusted component name
            imports: [RouterTestingModule, HttpClientTestingModule],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: FlightService, useValue: mockFlightService } // Adjusted service name
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(FlightListComponent); // Adjusted component name
        component = fixture.componentInstance; // Adjusted component name
    });

    fit('should_create_FlightListComponent', () => { // Adjusted function name and component name
        expect(component).toBeTruthy();
    });

    fit('FlightListComponent_should_call_loadFlights_on_ngOnInit', () => { // Adjusted function name and method name
        spyOn(component, 'loadFlights'); // Adjusted method name
        fixture.detectChanges();
        expect(component['loadFlights']).toHaveBeenCalled(); // Adjusted method name
    });

});
