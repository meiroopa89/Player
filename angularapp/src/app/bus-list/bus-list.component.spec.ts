import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { BusListComponent } from './bus-list.component'; // Adjusted component name
import { BusService } from '../services/bus.service'; // Adjusted service name

describe('BusListComponent', () => { // Adjusted component name
    let component: BusListComponent; // Adjusted component name
    let fixture: ComponentFixture<BusListComponent>; // Adjusted component name
    let mockBusService: jasmine.SpyObj<BusService>; // Specify the type of mock

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockBusService = jasmine.createSpyObj<BusService>('BusService', ['getBuses', 'deleteBus'] as any); // Adjusted service name

        TestBed.configureTestingModule({
            declarations: [BusListComponent], // Adjusted component name
            imports: [RouterTestingModule, HttpClientTestingModule],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: BusService, useValue: mockBusService } // Adjusted service name
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(BusListComponent); // Adjusted component name
        component = fixture.componentInstance; // Adjusted component name
    });

    fit('should_create_BusListComponent', () => { // Adjusted function name and component name
        expect(component).toBeTruthy();
    });

    fit('BusListComponent_should_call_loadBuses_on_ngOnInit', () => { // Adjusted function name and method name
        spyOn(component, 'loadBuses'); // Adjusted method name
        fixture.detectChanges();
        expect(component.loadBuses).toHaveBeenCalled(); // Adjusted method name
    });

});
