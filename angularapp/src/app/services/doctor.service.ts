// src/app/services/Doctor.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Doctor } from '../models/doctor.model';


@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  private apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addDoctor(Doctor: Doctor): Observable<Doctor> {
    return this.http.post<Doctor>(`${this.apiUrl}api/Doctor`, Doctor);
  }

  getDoctors(): Observable<Doctor[]> {
    return this.http.get<Doctor[]>(`${this.apiUrl}api/Doctor`);
  }

  deleteDoctor(DoctorId: number): Observable<void> {
    const url = `${this.apiUrl}api/Doctor/${DoctorId}`; // Adjust the URL to match your API endpoint
    return this.http.delete<void>(url);
  }

  getDoctor(DoctorId: number): Observable<Doctor> {
    const url = `${this.apiUrl}api/Doctor/${DoctorId}`;
    return this.http.get<Doctor>(url);
  }
}
