import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { DeleteConfirmComponent } from './delete-confirm.component';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FitnessService } from '../services/fitness.service'; // Adjusted service name

describe('DeleteConfirmComponent', () => {
    let component: DeleteConfirmComponent;
    let fixture: ComponentFixture<DeleteConfirmComponent>;
    let router: Router;
    let activatedRoute: ActivatedRoute;
    let mockFitnessService: jasmine.SpyObj<FitnessService>; // Adjusted service name

    beforeEach(waitForAsync(() => {
        mockFitnessService = jasmine.createSpyObj<FitnessService>('FitnessService', ['getFitnessClass', 'deleteFitnessClass']); // Adjusted service name and methods

        TestBed.configureTestingModule({
            imports: [RouterTestingModule, HttpClientModule, FormsModule, HttpClientTestingModule],
            declarations: [DeleteConfirmComponent],
            providers: [
                { provide: FitnessService, useValue: mockFitnessService } // Adjusted service name
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

    fit('DeleteConfirmComponent_should_call_deleteFitnessClass_method_when_confirmDelete_is_called', () => {
        const fitnessId = 1; // Adjusted ID name

        mockFitnessService.deleteFitnessClass.and.returnValue(of(null)); // Adjusted method name

        component.confirmDelete(fitnessId); // Adjusted parameter name

        expect(mockFitnessService.deleteFitnessClass).toHaveBeenCalledWith(fitnessId); // Adjusted method name and parameter
    });
});
