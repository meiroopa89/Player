import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FitnessListComponent } from './fitness-list.component'; // Adjusted component name
import { FitnessService } from '../services/fitness.service'; // Adjusted service name

describe('FitnessListComponent', () => { // Adjusted component name
    let component: FitnessListComponent; // Adjusted component name
    let fixture: ComponentFixture<FitnessListComponent>; // Adjusted component name
    let mockFitnessService: jasmine.SpyObj<FitnessService>; // Specify the type of mock

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockFitnessService = jasmine.createSpyObj<FitnessService>('FitnessService', ['getFitnessClasses', 'deleteFitnessClass'] as any); // Adjusted service name

        TestBed.configureTestingModule({
            declarations: [FitnessListComponent], // Adjusted component name
            imports: [RouterTestingModule, HttpClientTestingModule],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: FitnessService, useValue: mockFitnessService } // Adjusted service name
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(FitnessListComponent); // Adjusted component name
        component = fixture.componentInstance; // Adjusted component name
    });

    fit('should_create_FitnessListComponent', () => { // Adjusted function name and component name
        expect(component).toBeTruthy();
    });

    fit('FitnessListComponent_should_call_loadFitnessClasses_on_ngOnInit', () => { // Adjusted function name and method name
        spyOn(component, 'loadFitnessClasses'); // Adjusted method name
        fixture.detectChanges();
        expect(component.loadFitnessClasses).toHaveBeenCalled(); // Adjusted method name
    });

});
