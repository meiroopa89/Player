import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { CarService } from '../services/car.service'; // Import CarService
import { CarListComponent } from './car-list.component'; // Adjust the import path
import { of } from 'rxjs';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Car } from '../models/car.model'; // Import Car model

describe('CarListComponent', () => {
    let component: CarListComponent;
    let fixture: ComponentFixture<CarListComponent>;
    let mockCarService: jasmine.SpyObj<CarService>; // Specify the type of mock

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockCarService = jasmine.createSpyObj<CarService>('CarService', ['getCars', 'deleteCar'] as any);

        TestBed.configureTestingModule({
            declarations: [CarListComponent],
            imports: [RouterTestingModule, HttpClientTestingModule],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: CarService, useValue: mockCarService }
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(CarListComponent);
        component = fixture.componentInstance;
    });

    fit('should create CarListComponent', () => { // Change the function name
        expect(component).toBeTruthy();
    });

    fit('CarListComponent should call loadCars on ngOnInit', () => { // Change the function name
        spyOn(component, 'loadCars'); // Adjust the method name
        fixture.detectChanges();
        expect(component.loadCars).toHaveBeenCalled(); // Adjust the method name
    });

});
