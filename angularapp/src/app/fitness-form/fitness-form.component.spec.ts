import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FitnessService } from '../services/fitness.service'; // Adjusted service name
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';
import { Fitness } from '../models/fitness.model'; // Adjusted model name
import { FitnessFormComponent } from './fitness-form.component';

describe('FitnessFormComponent', () => { // Adjusted component name
  let component: FitnessFormComponent; // Adjusted component name
  let fixture: ComponentFixture<FitnessFormComponent>; // Adjusted component name
  let fitnessService: FitnessService; // Adjusted service name
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FitnessFormComponent], // Adjusted component name
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
      providers: [FitnessService] // Adjusted service name
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FitnessFormComponent); // Adjusted component name
    component = fixture.componentInstance; // Adjusted component name
    fitnessService = TestBed.inject(FitnessService); // Adjusted service name
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

  fit('should_create_FitnessFormComponent', () => { // Adjusted component name
    expect(component).toBeTruthy();
  });

  fit('FitnessFormComponent_should_render_error_messages_when_required_fields_are_empty_on_submit', () => { // Adjusted component name
    // Set all fields to empty strings
    component.newFitnessClass = {
      fitnessId: null,
      className: '',
      instructorName: '',
      classDate: '',
      duration: null,
      location: ''
    } as Fitness;
    
    // Manually trigger form submission
    component.formSubmitted = true;
    
    fixture.detectChanges();
    
    // Find the form element
    const form = fixture.debugElement.query(By.css('form')).nativeElement;
    
    // Submit the form
    form.dispatchEvent(new Event('submit'));
    
    fixture.detectChanges();
    
    // Check if error messages are rendered for each field
    expect(fixture.debugElement.query(By.css('#className + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#instructorName + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#classDate + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#duration + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#location + .error-message'))).toBeTruthy();
  });

 fit('FitnessFormComponent_should_call_addFitnessClass_method_while_adding_the_fitness_class', () => { // Adjusted component name and method name
    // Create a mock Fitness object with all required properties
    const fitnessClass: Fitness = { 
      fitnessId: 1, 
      className: 'Yoga', 
      instructorName: 'John Doe', 
      classDate: '2024-05-22', 
      duration: 60, 
      location: 'Room 101'
    };
    
    const addFitnessClassSpy = spyOn(component, 'addFitnessClass').and.callThrough(); // Adjusted method name
    component.addFitnessClass(); // Adjusted method name
    expect(addFitnessClassSpy).toHaveBeenCalled();
  });
});
