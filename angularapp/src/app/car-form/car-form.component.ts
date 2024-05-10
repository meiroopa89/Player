import { Component } from '@angular/core';
import { Car } from '../models/car.model';
import { CarService } from '../services/car.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-car-form',
  templateUrl: './car-form.component.html',
  styleUrls: ['./car-form.component.css']
})
export class CarFormComponent {
  newCar: Car = {
    id: 0,
    make: '',
    model: '',
    year: 0,
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
    const fieldValue = this.newCar[fieldName];
    return !fieldValue && (this.formSubmitted || fieldValue?.touched);
  }

  isFormValid(): boolean {
    return !this.isFieldInvalid('make') && !this.isFieldInvalid('model') &&
      !this.isFieldInvalid('year') && !this.isFieldInvalid('color') &&
      !this.isFieldInvalid('mileage') && !this.isFieldInvalid('price');
  }
}
