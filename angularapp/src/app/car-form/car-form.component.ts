import { Component } from '@angular/core';
import { Car } from '../models/car.model';
import { CarService } from '../services/car.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-Car-form',
  templateUrl: './Car-form.component.html',
  styleUrls: ['./Car-form.component.css']
})
export class CarFormComponent {
  newCar: Car = {
    id: 0,
    make: '',
    model: '',
    year: '',
    color: '',
    mileage: 0,
    price: 0
  }; // Initialize newCar with empty fields

  formSubmitted = false; // Track form submission

  constructor(private carService: CarService, private router: Router) { }

  addCar(): void {
    this.formSubmitted = true; // Set formSubmitted to true on form submission
    if (this.isFormValid()) {
      this.carService.addCar(this.newCar).subscribe(() => {
        console.log('Car added successfully!');
        this.router.navigate(['/viewCars']);
      });
    }
  }
  
  isFieldInvalid(fieldName: string): boolean {
    const field = this.newCar[fieldName];
    return !field && (this.formSubmitted || this.newCar[fieldName].touched);
  }
  isFormValid(): boolean {
    return !this.isFieldInvalid('firstName') && !this.isFieldInvalid('lastName') &&
      !this.isFieldInvalid('specialization') && !this.isFieldInvalid('phoneNumber') &&
      !this.isFieldInvalid('email') && !this.isFieldInvalid('address');
  }
}