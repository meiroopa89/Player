import { Component } from '@angular/core';
import { Doctor } from '../models/car.model';
import { DoctorService } from '../services/car.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctor-form',
  templateUrl: './doctor-form.component.html',
  styleUrls: ['./doctor-form.component.css']
})
export class DoctorFormComponent {
  newDoctor: Doctor = {
    id: 0,
    firstName: '',
    lastName: '',
    specialization: '',
    phoneNumber: '',
    email: '',
    address: ''
  }; // Initialize newDoctor with empty fields

  formSubmitted = false; // Track form submission

  constructor(private doctorService: DoctorService, private router: Router) { }

  addDoctor(): void {
    this.formSubmitted = true; // Set formSubmitted to true on form submission
    if (this.isFormValid()) {
      this.doctorService.addDoctor(this.newDoctor).subscribe(() => {
        console.log('Doctor added successfully!');
        this.router.navigate(['/viewDoctors']);
      });
    }
  }
  
  isFieldInvalid(fieldName: string): boolean {
    const field = this.newDoctor[fieldName];
    return !field && (this.formSubmitted || this.newDoctor[fieldName].touched);
  }
  isFormValid(): boolean {
    return !this.isFieldInvalid('firstName') && !this.isFieldInvalid('lastName') &&
      !this.isFieldInvalid('specialization') && !this.isFieldInvalid('phoneNumber') &&
      !this.isFieldInvalid('email') && !this.isFieldInvalid('address');
  }
}