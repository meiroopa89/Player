// src/app/services/Car.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Car } from '../models/car.model';


@Injectable({
  providedIn: 'root'
})
export class CarService {
  private apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addCar(Car: Car): Observable<Car> {
    return this.http.post<Car>(`${this.apiUrl}api/Car`, Car);
  }

  getCars(): Observable<Car[]> {
    return this.http.get<Car[]>(`${this.apiUrl}api/Car`);
  }

  deleteCar(CarId: number): Observable<void> {
    const url = `${this.apiUrl}api/Car/${CarId}`; // Adjust the URL to match your API endpoint
    return this.http.delete<void>(url);
  }

  getCar(CarId: number): Observable<Car> {
    const url = `${this.apiUrl}api/Car/${CarId}`;
    return this.http.get<Car>(url);
  }
}
