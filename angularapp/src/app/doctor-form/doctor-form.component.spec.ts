import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { RouterTestingModule } from '@angular/router/testing';
import { DoctorFormComponent } from './doctor-form.component';
import { DoctorService } from '../services/doctor.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { Doctor } from '../models/doctor.model';
import { fakeAsync, tick } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { DoctorListComponent } from '../doctor-list/doctor-list.component';

describe('DoctorFormComponent', () => {
  let component: DoctorFormComponent;
  let fixture: ComponentFixture<DoctorFormComponent>;
  let doctorService: DoctorService;
  let router: Router;
  let doctorListComponent: DoctorListComponent;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DoctorFormComponent],
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
      providers: [
        DoctorService,
      ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DoctorFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

    doctorService = TestBed.inject(DoctorService);
    router = TestBed.inject(Router);

  });

  fit('should create DoctorFormComponent', () => {
    expect(component).toBeTruthy();
  });

  fit('DoctorFormComponent should not render any error messages when all fields are filled', () => {
    const compiled = fixture.nativeElement;
    const form = compiled.querySelector('form');

    // Fill all fields
    component.newDoctor = {
      id: null, // or omit this line if doctorId is auto-generated
      firstName: 'Test First Name',
      lastName: 'Test Last Name',
      specialization: 'Test Specialization',
      phoneNumber: 'Test Phone Number',
      email: 'test@example.com',
      address: 'Test Address'
    } as Doctor;

    fixture.detectChanges();

    form.dispatchEvent(new Event('submit')); // Submit the form

    // Check if no error messages are rendered
    expect(compiled.querySelector('#firstNameError')).toBeNull();
    expect(compiled.querySelector('#lastNameError')).toBeNull();
    expect(compiled.querySelector('#specializationError')).toBeNull();
    expect(compiled.querySelector('#phoneNumberError')).toBeNull();
    expect(compiled.querySelector('#emailError')).toBeNull();
    expect(compiled.querySelector('#addressError')).toBeNull();
  });

  fit('DoctorFormComponent should call addDoctor method while adding the doctor', () => {
    // Create a mock Doctor object with all required properties
    const doctor: Doctor = { 
      id: 1, 
      firstName: 'Test First Name', 
      lastName: 'Test Last Name', 
      specialization: 'Test Specialization', 
      phoneNumber: 'Test Phone Number', 
      email: 'test@example.com', 
      address: 'Test Address'
    };
    const addDoctorSpy = spyOn(component, 'addDoctor').and.callThrough();
    component.addDoctor();
    expect(addDoctorSpy).toHaveBeenCalled();
  });
});
