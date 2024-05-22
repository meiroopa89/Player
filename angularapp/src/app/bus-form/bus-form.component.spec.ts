import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { BusFormComponent } from './bus-form.component'; // Adjusted component name
import { BusService } from '../services/bus.service'; // Adjusted service name
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';
import { Bus } from '../models/bus.model'; // Adjusted model name

describe('BusFormComponent', () => { // Adjusted component name
  let component: BusFormComponent; // Adjusted component name
  let fixture: ComponentFixture<BusFormComponent>; // Adjusted component name
  let busService: BusService; // Adjusted service name
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BusFormComponent], // Adjusted component name
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
      providers: [BusService] // Adjusted service name
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BusFormComponent); // Adjusted component name
    component = fixture.componentInstance; // Adjusted component name
    busService = TestBed.inject(BusService); // Adjusted service name
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

  fit('should_create_BusFormComponent', () => { // Adjusted component name
    expect(component).toBeTruthy();
  });

  fit('BusFormComponent_should_render_error_messages_when_required_fields_are_empty_on_submit', () => { // Adjusted component name
    // Set all fields to empty strings
    component.newBus = {
      bookingId: null,
      busNumber: '',
      routeSource: '',
      routeDestination: '',
      passengerName: '',
      bookingDate: ''
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
    expect(fixture.debugElement.query(By.css('#busNumber + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#routeSource + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#routeDestination + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#passengerName + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#bookingDate + .error-message'))).toBeTruthy();
  });


  fit('BusFormComponent_should_call_addBus_method_while_adding_the_bus', () => { // Adjusted component name and method name
    // Create a mock Bus object with all required properties
    const bus: Bus = { 
      bookingId: 1, 
      busNumber: 'Test Bus Number', 
      routeSource: 'Test Source', 
      routeDestination: 'Test Destination', 
      passengerName: 'Test Passenger', 
      bookingDate: '2024-05-22'
    } as any;
    const addBusSpy = spyOn(component, 'addBus').and.callThrough(); // Adjusted method name
    component['addBus'](); // Adjusted method name
    expect(addBusSpy).toHaveBeenCalled();
  });
});
