import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { DoctorFormComponent } from './doctor-form.component';
import { DoctorService } from '../services/doctor.service';
import { Router } from '@angular/router';
import { of } from 'rxjs';

describe('DoctorFormComponent', () => {
    let component: DoctorFormComponent;
    let fixture: ComponentFixture<DoctorFormComponent>;
    let doctorService: DoctorService;
    let router: Router;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [FormsModule],
            declarations: [DoctorFormComponent],
            providers: [DoctorService, { provide: Router, useClass: class { navigate = jasmine.createSpy('navigate'); } }]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(DoctorFormComponent);
        component = fixture.componentInstance;
        doctorService = TestBed.inject(DoctorService);
        router = TestBed.inject(Router);
    });

    fit('should create DoctorFormComponent', () => {
        expect(component).toBeTruthy();
    });

    fit('DoctorFormComponent should have a form for adding a doctor', () => {
        const formElement: HTMLFormElement = fixture.nativeElement.querySelector('form');
        expect(formElement).toBeTruthy();
    });

    fit('DoctorFormComponent should have form controls for doctor details', () => {
        const formElement: HTMLFormElement = fixture.nativeElement.querySelector('form');
        expect(formElement.querySelector('#firstName')).toBeTruthy();
        expect(formElement.querySelector('#lastName')).toBeTruthy();
        expect(formElement.querySelector('#specialization')).toBeTruthy();
        expect(formElement.querySelector('#phoneNumber')).toBeTruthy();
        expect(formElement.querySelector('#email')).toBeTruthy();
        expect(formElement.querySelector('#address')).toBeTruthy();
    });

    fit('DoctorFormComponent_should_have_a_button_for_adding_a doctor', () => {
        const buttonElement: HTMLButtonElement = fixture.nativeElement.querySelector('button');
        expect(buttonElement).toBeTruthy();
        expect(buttonElement.textContent).toContain('Add Doctor');
    });

    fit('DoctorFormComponent should have addDoctor method', () => {
        expect(component.addDoctor).toBeTruthy();
    });
  });