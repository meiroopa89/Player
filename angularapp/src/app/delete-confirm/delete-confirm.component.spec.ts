import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { DeleteConfirmComponent } from './delete-confirm.component';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CarService } from '../services/car.service'; // Adjusted service name
import { Car } from '../models/recipe.model'; // Adjusted model name

describe('DeleteConfirmComponent', () => {
    let component: DeleteConfirmComponent;
    let fixture: ComponentFixture<DeleteConfirmComponent>;
    let router: Router;
    let activatedRoute: ActivatedRoute;
    let mockCarService: jasmine.SpyObj<CarService>; // Adjusted service name

    beforeEach(waitForAsync(() => {
        mockCarService = jasmine.createSpyObj<CarService>('CarService', ['getCar', 'deleteCar'] as any); // Adjusted service name and methods

        TestBed.configureTestingModule({
            imports: [RouterTestingModule, HttpClientModule, FormsModule, HttpClientTestingModule],
            declarations: [DeleteConfirmComponent],
            providers: [
                { provide: CarService, useValue: mockCarService } // Adjusted service name
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

    it('should create DeleteConfirmComponent', () => {
        expect(component).toBeTruthy();
    });

    it('DeleteConfirmComponent should call deleteCar method when confirmDelete is called', () => {
        const carId = 1; // Adjusted ID name
        
        mockCarService.deleteCar.and.returnValue(of(null)); // Adjusted method name

        component.confirmDelete(carId); // Adjusted parameter name

        expect(mockCarService.deleteCar).toHaveBeenCalledWith(carId); // Adjusted method name and parameter
    });
});
