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

  fit('should_create_DoctorFormComponent', () => {
    expect(component).toBeTruthy();
  });

  fit('DoctorFormComponent_should_render_error_messages_when_required_fields_are_empty_on_submit', () => {
    // Set all fields to empty strings
    component.newDoctor = {
      id: null,
      firstName: '',
      lastName: '',
      specialization: '',
      phoneNumber: '',
      email: '',
      address: ''
    };
  
    // Manually trigger form submission
    component.formSubmitted = true;
  
    fixture.detectChanges();
  
    // Find the form element
    const form = fixture.debugElement.query(By.css('form')).nativeElement;
  
    // Submit the form
    form.dispatchEvent(new Event('submit'));
  
    fixture.detectChanges();
  
    // Check if error messages are rendered for each field
    expect(fixture.debugElement.query(By.css('#firstName + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#lastName + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#specialization + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#phoneNumber + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#email + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#address + .error-message'))).toBeTruthy();
  });
  

  fit('DoctorFormComponent_should_call_addDoctor_method_while_adding_the_doctor', () => {
    // Create a mock Doctor object with all required properties
    const doctor: Doctor = { 
      id: 1, 
      firstName: 'Test First Name', 
      lastName: 'Test Last Name', 
      specialization: 'Test Specialization', 
      phoneNumber: 'Test Phone Number', 
      email: 'test@example.com', 
      address: 'Test Address'
    } as any;
    const addDoctorSpy = spyOn(component, 'addDoctor').and.callThrough();
    component.addDoctor();
    expect(addDoctorSpy).toHaveBeenCalled();
  });
});
