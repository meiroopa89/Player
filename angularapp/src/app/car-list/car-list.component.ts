// car-list.component.ts
import { Component, OnInit } from '@angular/core';
import { Car } from '../models/phone.model'; // Import car model
import { CarService} from '../services/car.service'; // Import carService
import { Router } from '@angular/router';

@Component({
  selector: 'app-car-list', // Change selector to 'app-car-list'
  templateUrl: './car-list.component.html', // Adjust the template URL
  styleUrls: ['./car-list.component.css'] // Adjust the style URL
})
export class CarListComponent implements OnInit {
  cars: Car[] = []; // Change recipes to cars

  constructor(private carService: CarService, private router: Router) { } // Adjust service name

  ngOnInit(): void {
    this.loadCars(); // Adjust the method name
  }

  loadCars(): void {
    this.carService.getCars().subscribe(cars => this.cars = cars); 
    console.log(this.cars);// Adjust the service method name
  }

  deleteCar(carId: number): void { // Adjust the method name and parameter
    // Navigate to confirm delete page with the car ID as a parameter
    this.router.navigate(['/confirmDelete', carId]);
  }
}
