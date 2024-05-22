import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Bus } from '../models/bus.model'; // Import Bus model

@Injectable({
  providedIn: 'root'
})
export class BusService {
  private apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addBus(bus: Bus): Observable<Bus> { // Adjust method name and parameter
    return this.http.post<Bus>(`${this.apiUrl}/api/Bus`, bus); // Adjust endpoint and parameter
  }

  getBuses(): Observable<Bus[]> { // Adjust method name
    return this.http.get<Bus[]>(`${this.apiUrl}/api/Bus`); // Adjust endpoint
  }

  deleteBus(bookingId: number): Observable<void> { // Adjust method name and parameter
    const url = `${this.apiUrl}/api/Bus/${bookingId}`; // Adjust the URL to match your API endpoint
    return this.http.delete<void>(url); // Adjust endpoint and parameter
  }

  getBus(bookingId: number): Observable<Bus> { // Adjust method name and return type
    const url = `${this.apiUrl}/api/Bus/${bookingId}`; // Adjust the URL to match your API endpoint
    return this.http.get<Bus>(url); // Adjust endpoint and return type
  }
}
