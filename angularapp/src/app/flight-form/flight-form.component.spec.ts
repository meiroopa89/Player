import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FlightFormComponent } from './flight-form.component'; // Adjusted component name
import { FlightService } from '../services/flight.service'; // Adjusted service name
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';
import { Flight } from '../models/flight.model'; // Adjusted model name

describe('FlightFormComponent', () => { // Adjusted component name
  let component: FlightFormComponent; // Adjusted component name
  let fixture: ComponentFixture<FlightFormComponent>; // Adjusted component name
  let flightService: FlightService; // Adjusted service name
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightFormComponent], // Adjusted component name
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
      providers: [FlightService] // Adjusted service name
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightFormComponent); // Adjusted component name
    component = fixture.componentInstance; // Adjusted component name
    flightService = TestBed.inject(FlightService); // Adjusted service name
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

  fit('should_create_FlightFormComponent', () => { // Adjusted component name
    expect(component).toBeTruthy();
  });

  fit('FlightFormComponent_should_render_error_messages_when_required_fields_are_empty_on_submit', () => { // Adjusted component name
    // Set all fields to empty strings
    component.newFlight = {
      flightId: null,
      name: '',
      departureAirport: '',
      destinationAirport: '',
      departureDate: null,
      arrivalDate: null
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
    expect(fixture.debugElement.query(By.css('#name + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#departureAirport + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#destinationAirport + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#departureDate + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#arrivalDate + .error-message'))).toBeTruthy();
  });


  fit('FlightFormComponent_should_call_addFlight_method_while_adding_the_flight', () => { // Adjusted component name and method name
    // Create a mock Flight object with all required properties
    const flight: Flight = { 
      flightId: 1, 
      name: 'Test Airline', 
      departureAirport: 'Test Departure', 
      destinationAirport: 'Test Destination', 
      departureDate: new Date(), 
      arrivalDate: new Date()
    } as any;
    const addFlightSpy = spyOn(component, 'addFlight').and.callThrough(); // Adjusted method name
    component.addFlight(); // Adjusted method name
    expect(addFlightSpy).toHaveBeenCalled();
  });
});
