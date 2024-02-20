import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/api.config';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  public apiUrl = apiUrl;

  constructor(private http: HttpClient) {}

  addEvent(eventData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/api/event`, eventData);
  }

  getAllEvents(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/api/event`);
  }

  updateEvent(eventData: any): Observable<any> {
    const id = eventData.EventId;
    return this.http.put(`${this.apiUrl}/api/event/${id}`, eventData);
  }

  deleteEvent(eventId: any): Observable<any> {
    // const id = eventData.EventId;
    return this.http.delete(`${this.apiUrl}/api/event/${eventId}`);
  }

  getEventById(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/api/event/${id}`);
  }
}
