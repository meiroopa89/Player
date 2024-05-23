import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Fitness } from '../models/fitness.model'; // Import Fitness model

@Injectable({
  providedIn: 'root'
})
export class FitnessService {
  private apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addFitnessClass(fitnessClass: Fitness): Observable<Fitness> { // Adjust method name and parameter
    return this.http.post<Fitness>(`${this.apiUrl}/api/Fitness`, fitnessClass); // Adjust endpoint and parameter
  }

  getFitnessClasses(): Observable<Fitness[]> { // Adjust method name
    return this.http.get<Fitness[]>(`${this.apiUrl}/api/Fitness`); // Adjust endpoint
  }

  deleteFitnessClass(fitnessId: number): Observable<void> { // Adjust method name and parameter
    const url = `${this.apiUrl}/api/Fitness/${fitnessId}`; // Adjust the URL to match your API endpoint
    return this.http.delete<void>(url); // Adjust endpoint and parameter
  }

  getFitnessClass(fitnessId: number): Observable<Fitness> { // Adjust method name and return type
    const url = `${this.apiUrl}/api/Fitness/${fitnessId}`; // Adjust the URL to match your API endpoint
    return this.http.get<Fitness>(url); // Adjust endpoint and return type
  }
}
