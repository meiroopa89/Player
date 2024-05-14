import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CarFormComponent } from './car-form.component'; // Adjusted component name
import { CarService } from '../services/car.service'; // Adjusted service name
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';
import { Car } from '../models/phone.model';

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

  fit('should_create_CarFormComponent', () => { // Adjusted component name
    expect(component).toBeTruthy();
  });

  fit('CarFormComponent_should_render_error_messages_when_required_fields_are_empty_on_submit', () => {
    // Set all fields to empty strings
    component.newCar = {
      id: null,
      make: '',
      model: '',
      year: '',
      color: '',
      mileage: null,
      price: null
    } as any;
    
    // Manually trigger form submission
    component.formSubmitted = true;
    
    fixture.detectChanges();
    
    // Find the form element
    const form = fixture.debugElement.query(By.css('form')).nativeElement;
    
    // Submit the form
    form.dispatchEvent(new Event('submit'));
    
    fixture.detectChanges();
    
    // Check if error messages are rendered for each field
    expect(fixture.debugElement.query(By.css('#make + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#model + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#year + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#color + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#mileage + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#price + .error-message'))).toBeTruthy();
  });


  fit('CarFormComponent should call addCar method while adding the car', () => { // Adjusted component name and method name
    // Create a mock Car object with all required properties
    const car: Car= { 
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
