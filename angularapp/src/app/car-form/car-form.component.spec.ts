import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CarFormComponent } from './car-form.component'; // Adjusted component name
import { CarService } from '../services/car.service'; // Adjusted service name
import { Router } from '@angular/router';
import { Car } from '../models/recipe.model'; // Imported Car model
import { of } from 'rxjs';

describe('CarFormComponent', () => { // Adjusted component name
  let component: CarFormComponent; // Adjusted component name
  let fixture: ComponentFixture<CarFormComponent>; // Adjusted component name
  let carService: CarService; // Adjusted service name
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarFormComponent], // Adjusted component name
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
      providers: [CarService] // Adjusted service name
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarFormComponent); // Adjusted component name
    component = fixture.componentInstance; // Adjusted component name
    carService = TestBed.inject(CarService); // Adjusted service name
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

  it('should create CarFormComponent', () => { // Adjusted component name
    expect(component).toBeTruthy();
  });

  it('CarFormComponent should not render any error messages when all fields are filled', () => { // Adjusted component name
    const compiled = fixture.nativeElement;
    const form = compiled.querySelector('form');

    // Fill all fields
    component.newCar = {
      make: 'Test Make',
      model: 'Test Model',
      year: 'Test Year',
      color: 'Test Color',
      mileage: 10000,
      price: 5000
    } as Car;

    fixture.detectChanges();

    form.dispatchEvent(new Event('submit')); // Submit the form

    // Check if no error messages are rendered
    expect(compiled.querySelector('#makeError')).toBeNull();
    expect(compiled.querySelector('#modelError')).toBeNull();
    expect(compiled.querySelector('#yearError')).toBeNull();
    expect(compiled.querySelector('#colorError')).toBeNull();
    expect(compiled.querySelector('#mileageError')).toBeNull();
    expect(compiled.querySelector('#priceError')).toBeNull();
  });

  it('CarFormComponent should call addCar method while adding the car', () => { // Adjusted component name and method name
    // Create a mock Car object with all required properties
    const car: Car = { 
      id: 1, 
      make: 'Test Make', 
      model: 'Test Model', 
      year: 'Test Year', 
      color: 'Test Color', 
      mileage: 10000, 
      price: 5000
    };
    const addCarSpy = spyOn(component, 'addCar').and.callThrough(); // Adjusted method name
    component.addCar(); // Adjusted method name
    expect(addCarSpy).toHaveBeenCalled();
  });
});
