import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { DeleteConfirmComponent } from './delete-confirm.component';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http'; // Import HttpClientModule
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { DoctorService } from '../services/doctor.service'; // Import DoctorService
import { Doctor } from '../models/doctor.model'; // Import Doctor model

describe('DeleteConfirmComponent', () => {
    let component: DeleteConfirmComponent;
    let fixture: ComponentFixture<DeleteConfirmComponent>;
    let router: Router;
    let activatedRoute: ActivatedRoute;
    let mockDoctorService: jasmine.SpyObj<DoctorService>; // Declare mockDoctorService

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockDoctorService = jasmine.createSpyObj<DoctorService>('DoctorService', ['getDoctor', 'deleteDoctor'] as any);

        TestBed.configureTestingModule({
            imports: [RouterTestingModule, HttpClientModule, FormsModule, HttpClientTestingModule], // Add HttpClientModule and HttpClientTestingModule to imports
            declarations: [DeleteConfirmComponent],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: DoctorService, useValue: mockDoctorService }
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

    fit('should create DeleteConfirmComponent', () => { // Adjust the function name
        expect(component).toBeTruthy();
    });

    fit('DeleteConfirmComponent should call deleteDoctor method when confirmDelete is called', () => { // Adjust the function name
        const doctorId = 1; // Adjust the doctorId
        
        // Spy on the deleteDoctor method of the DoctorService
        mockDoctorService.deleteDoctor.and.returnValue(of(null)); // Adjust the method name

        // Call the confirmDelete method
        component.confirmDelete(doctorId); // Adjust the parameter name

        // Expect the deleteDoctor method to have been called with the doctorId
        expect(mockDoctorService.deleteDoctor).toHaveBeenCalledWith(doctorId); // Adjust the method name and parameter
    });
});
