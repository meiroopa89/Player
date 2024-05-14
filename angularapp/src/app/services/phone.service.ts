import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Phone } from '../models/phone.model'; // Import Phone model

@Injectable({
  providedIn: 'root'
})
export class PhoneService {
  private apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addPhone(phone: Phone): Observable<Phone> { // Adjust method name and parameter
    return this.http.post<Phone>(`${this.apiUrl}api/Phone`, phone); // Adjust endpoint and parameter
  }

  getPhones(): Observable<Phone[]> { // Adjust method name
    return this.http.get<Phone[]>(`${this.apiUrl}api/Phone`); // Adjust endpoint
  }

  deletePhone(phoneId: number): Observable<void> { // Adjust method name and parameter
    const url = `${this.apiUrl}api/Phone/${phoneId}`; // Adjust the URL to match your API endpoint
    return this.http.delete<void>(url); // Adjust endpoint and parameter
  }

  getPhone(phoneId: number): Observable<Phone> { // Adjust method name and return type
    const url = `${this.apiUrl}api/Phone/${phoneId}`; // Adjust the URL to match your API endpoint
    return this.http.get<Phone>(url); // Adjust endpoint and return type
  }
}
