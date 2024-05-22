import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FlightService } from '../services/bus.service'; // Adjusted service name
import { Flight } from '../models/bus.model'; // Adjusted model name

@Component({
  selector: 'app-flight-list', // Adjusted selector
  templateUrl: './flight-list.component.html', // Adjusted template URL
  styleUrls: ['./flight-list.component.css'] // Adjusted style URL
})
export class FlightListComponent implements OnInit {
  flights: Flight[] = []; // Adjusted property name

  constructor(private flightService: FlightService, private router: Router) { } // Adjusted service name

  ngOnInit(): void {
    this.loadFlights(); // Adjusted method name
  }

  loadFlights(): void {
    this.flightService.getFlights().subscribe(flights => { // Adjusted method name
      this.flights = flights;
      console.log(this.flights);
    });
  }

  deleteFlight(flightId: number): void { // Adjusted method name and parameter
    // Navigate to confirm delete page with the flight ID as a parameter
    this.router.navigate(['/confirmDelete', flightId]);
  }
}
