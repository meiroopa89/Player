import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from '../services/car.service'; // Adjusted service name
import { Car } from '../models/phone.model';

@Component({
  selector: 'app-delete-confirm',
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  carId: number;
  car: Car = {} as Car; // Initialize car property with an empty object

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private carService: CarService // Adjusted service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.carId = +params['id']; // Adjust parameter name
      this.carService.getCar(this.carId).subscribe(
        (car: Car) => {
          this.car = car;
        },
        error => {
          console.error('Error fetching car:', error);
        }
      );
    });
  }

  confirmDelete(carId: number): void { // Adjust method signature
    this.carService.deleteCar(carId).subscribe(
      () => {
        console.log('Car deleted successfully.');
        this.router.navigate(['/viewCars']); // Adjust the route
      },
      (error) => {
        console.error('Error deleting car:', error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/viewCars']); // Adjust the route
  }
}
