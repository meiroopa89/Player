import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { DoctorService } from '../services/doctor.service'; // Import DoctorService
import { DoctorListComponent } from './doctor-list.component'; // Adjust the import path
import { of } from 'rxjs';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Doctor } from '../models/doctor.model'; // Import Doctor model

describe('DoctorListComponent', () => {
    let component: DoctorListComponent;
    let fixture: ComponentFixture<DoctorListComponent>;
    let mockDoctorService: jasmine.SpyObj<DoctorService>; // Specify the type of mock

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockDoctorService = jasmine.createSpyObj<DoctorService>('DoctorService', ['getDoctors', 'deleteDoctor'] as any);

        TestBed.configureTestingModule({
            declarations: [DoctorListComponent],
            imports: [RouterTestingModule, HttpClientTestingModule],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: DoctorService, useValue: mockDoctorService }
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(DoctorListComponent);
        component = fixture.componentInstance;
    });

    fit('should_create_DoctorListComponent', () => { // Change the function name
        expect(component).toBeTruthy();
    });

    fit('DoctorListComponent_should_call_loadDoctors_on_ngOnInit', () => { // Change the function name
        spyOn(component, 'loadDoctors'); // Adjust the method name
        fixture.detectChanges();
        expect(component.loadDoctors).toHaveBeenCalled(); // Adjust the method name
    });

});
