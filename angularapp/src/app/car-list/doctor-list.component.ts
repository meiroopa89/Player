// doctor-list.component.ts
import { Component, OnInit } from '@angular/core';
import { Doctor } from '../models/car.model'; // Import Doctor model
import { DoctorService } from '../services/car.service'; // Import DoctorService
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctor-list', // Change selector to 'app-doctor-list'
  templateUrl: './doctor-list.component.html', // Adjust the template URL
  styleUrls: ['./doctor-list.component.css'] // Adjust the style URL
})
export class DoctorListComponent implements OnInit {
  doctors: Doctor[] = []; // Change recipes to doctors

  constructor(private doctorService: DoctorService, private router: Router) { } // Adjust service name

  ngOnInit(): void {
    this.loadDoctors(); // Adjust the method name
  }

  loadDoctors(): void {
    this.doctorService.getDoctors().subscribe(doctors => this.doctors = doctors); // Adjust the service method name
  }

  deleteDoctor(doctorId: number): void { // Adjust the method name and parameter
    // Navigate to confirm delete page with the doctor ID as a parameter
    this.router.navigate(['/confirmDelete', doctorId]);
  }
}
