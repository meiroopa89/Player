import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Flight } from '../models/bus.model'; // Adjusted model name
import { FlightService } from '../services/bus.service'; // Adjusted service name

@Component({
  selector: 'app-delete-confirm', // Adjusted component selector
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  flightId: number;
  flight: Flight = {} as Flight; // Initialize flight property with an empty object

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private flightService: FlightService // Adjusted service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.flightId = +params['id']; // Adjust parameter name
      this.flightService.getFlight(this.flightId).subscribe(
        (flight: Flight) => { // Adjust type casting
          this.flight = flight;
        },
        error => {
          console.error('Error fetching flight:', error);
        }
      );
    });
  }

  confirmDelete(flightId: number): void { // Adjust method signature
    this.flightService.deleteFlight(flightId).subscribe(
      () => {
        console.log('Flight deleted successfully.');
        this.router.navigate(['/viewFlights']); // Adjust the route
      },
      (error) => {
        console.error('Error deleting flight:', error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/viewFlights']); // Adjust the route
  }
}
