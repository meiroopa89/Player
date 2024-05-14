// src/app/services/phone.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Phone } from '../models/phone.model'; // Adjusted import for Phone model

@Injectable({
  providedIn: 'root'
})
export class PhoneService { // Adjusted class name to PhoneService
  private apiUrl = 'https://example.com/api/'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addPhone(phone: Phone): Observable<Phone> { // Adjusted method name and parameter
    return this.http.post<Phone>(`${this.apiUrl}phones`, phone); // Adjusted endpoint URL
  }

  getPhones(): Observable<Phone[]> { // Adjusted method name and return type
    return this.http.get<Phone[]>(`${this.apiUrl}phones`); // Adjusted endpoint URL
  }

  deletePhone(phoneId: number): Observable<void> { // Adjusted method name and parameter
    const url = `${this.apiUrl}phones/${phoneId}`; // Adjusted endpoint URL
    return this.http.delete<void>(url);
  }

  getPhone(phoneId: number): Observable<Phone> { // Adjusted method name and parameter
    const url = `${this.apiUrl}phones/${phoneId}`; // Adjusted endpoint URL
    return this.http.get<Phone>(url);
  }
}
