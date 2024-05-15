import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Flight } from '../models/flight.model'; // Import Flight model

@Injectable({
  providedIn: 'root'
})
export class FlightService {
  private apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addFlight(flight: Flight): Observable<Flight> { // Adjust method name and parameter
    return this.http.post<Flight>(`${this.apiUrl}/api/Flight`, flight); // Adjust endpoint and parameter
  }

  getFlights(): Observable<Flight[]> { // Adjust method name
    return this.http.get<Flight[]>(`${this.apiUrl}/api/Flight`); // Adjust endpoint
  }

  deleteFlight(flightId: number): Observable<void> { // Adjust method name and parameter
    const url = `${this.apiUrl}/api/Flight/${flightId}`; // Adjust the URL to match your API endpoint
    return this.http.delete<void>(url); // Adjust endpoint and parameter
  }

  getFlight(flightId: number): Observable<Flight> { // Adjust method name and return type
    const url = `${this.apiUrl}/api/Flight/${flightId}`; // Adjust the URL to match your API endpoint
    return this.http.get<Flight>(url); // Adjust endpoint and return type
  }
}
