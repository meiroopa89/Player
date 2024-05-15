import { Component } from '@angular/core';
import { Flight } from '../models/flight.model';
import { Router } from '@angular/router';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-flight-form',
  templateUrl: './flight-form.component.html',
  styleUrls: ['./flight-form.component.css']
})
export class FlightFormComponent {
  newFlight: Flight = {
    flightId: 0,
    name: '',
    departureAirport: '',
    destinationAirport: '',
    departureDate: null,
    arrivalDate: null
  }; // Initialize newFlight with empty fields

  formSubmitted = false; // Track form submission

  constructor(private flightService: FlightService, private router: Router) { }

  addFlight(): void {
    this.formSubmitted = true; // Set formSubmitted to true on form submission
    if (this.isFormValid()) {
      this.flightService.addFlight(this.newFlight).subscribe(() => {
        console.log('Flight added successfully!');
        this.router.navigate(['/viewFlights']);
      });
    }
  }
  
  isFieldInvalid(fieldName: string): boolean {
    const fieldValue = this.newFlight[fieldName];
    return !fieldValue && (this.formSubmitted || fieldValue?.touched);
  }

  isFormValid(): boolean {
    return !this.isFieldInvalid('name') && !this.isFieldInvalid('departureAirport') &&
      !this.isFieldInvalid('destinationAirport') && !this.isFieldInvalid('departureDate') &&
      !this.isFieldInvalid('arrivalDate');
  }
}
