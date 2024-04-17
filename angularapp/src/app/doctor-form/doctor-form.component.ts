// src/app/doctor-form/doctor-form.component.ts
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
    firstName: '',
    lastName: '',
    specialization: '',
    phoneNumber: '',
    email: '',
    address: ''
  };

  constructor(private doctorService: DoctorService, private router: Router) { }

  addDoctor(): void {
    this.doctorService.addDoctor(this.newDoctor).subscribe(() => {
      console.log('Doctor added successfully!');
      this.router.navigate(['/viewDoctors']);
    });
  }
}
