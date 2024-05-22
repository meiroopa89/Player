import { Component } from '@angular/core';
import { Bus } from '../models/bus.model'; // Adjusted model name
import { Router } from '@angular/router';
import { BusService } from '../services/bus.service'; // Adjusted service name

@Component({
  selector: 'app-bus-form', // Adjusted selector
  templateUrl: './bus-form.component.html', // Adjusted template URL
  styleUrls: ['./bus-form.component.css'] // Adjusted style URL
})
export class BusFormComponent {
  newBus: Bus = { // Adjusted property name and type
    bookingId: 0,
    busNumber: '',
    routeSource: '',
    routeDestination: '',
    passengerName: '',
    bookingDate: ''
  }; // Initialize newBus with empty fields

  formSubmitted = false; // Track form submission

  constructor(private busService: BusService, private router: Router) { } // Adjusted service name

  addBus(): void { // Adjusted method name
    this.formSubmitted = true; // Set formSubmitted to true on form submission
    if (this.isFormValid()) {
      this.busService.addBus(this.newBus).subscribe(() => { // Adjusted method name
        console.log('Bus added successfully!'); // Adjusted success message
        this.router.navigate(['/viewBuses']); // Adjusted route
      });
    }
  }
  
  isFieldInvalid(fieldName: string): boolean { // Adjusted method name
    const fieldValue = this.newBus[fieldName];
    return !fieldValue && (this.formSubmitted || fieldValue?.touched);
  }

  isFormValid(): boolean { // Adjusted method name
    return !this.isFieldInvalid('busNumber') && !this.isFieldInvalid('routeSource') &&
      !this.isFieldInvalid('routeDestination') && !this.isFieldInvalid('passengerName') &&
      !this.isFieldInvalid('bookingDate');
  }
}
