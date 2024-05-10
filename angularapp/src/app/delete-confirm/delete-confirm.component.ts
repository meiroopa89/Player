// delete-confirm.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DoctorService } from '../services/car.service'; // Adjust service name
import { Doctor } from '../models/car.model'; // Import Doctor model

@Component({
  selector: 'app-delete-confirm',
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  doctorId: number;
  doctor: Doctor; // Initialize doctor property with an empty object

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private doctorService: DoctorService // Adjust service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.doctorId = +params['id']; // Adjust parameter name
      this.doctorService.getDoctor(this.doctorId).subscribe(
        (doctor: Doctor) => {
          this.doctor = doctor;
        },
        error => {
          console.error('Error fetching doctor:', error);
        }
      );
    });
  }

  confirmDelete(doctorId: number): void { // Adjust method signature
    this.doctorService.deleteDoctor(doctorId).subscribe(
      () => {
        console.log('Doctor deleted successfully.');
        this.router.navigate(['/viewDoctors']); // Adjust the route
      },
      (error) => {
        console.error('Error deleting doctor:', error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/viewDoctors']); // Adjust the route
  }
}
