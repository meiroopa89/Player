import { Component } from '@angular/core';
import { Doctor } from '../models/doctor.model';
import { DoctorService } from '../services/doctor.service'; // Corrected import statement
import { Router } from '@angular/router';


@Component({
  selector: 'app-doctor-form',
  templateUrl: './doctor-form.component.html',
  styleUrls: ['./doctor-form.component.css']
})

export class DoctorFormComponent {
  newDoctor: Doctor = {
    id: 0,
    name: '',
    description: '',
    ingredients: '',
    instructions: '',
    author: ''
  } as any;
  
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
    return !this.isFieldInvalid('name') && !this.isFieldInvalid('description') &&
      !this.isFieldInvalid('ingredients') && !this.isFieldInvalid('instructions') &&
      !this.isFieldInvalid('author');
  }
}

