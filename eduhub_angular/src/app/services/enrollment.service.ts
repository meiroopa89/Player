import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/apiconfig';
import { Enrollment } from '../models/enrollment.model';

@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {
  public apiUrl = apiUrl; // Update with your API URL

  constructor(private http: HttpClient) { } // Inject HttpClient

  getAllEnrollments(): Observable<Enrollment[]> {
    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<Enrollment[]>(`${this.apiUrl}/api/enrollment`, { headers });
  }

  updateEnrollmentStatus(id: string, enrollment: Enrollment): Observable<Enrollment> {
    console.log('updateEnrollmentStatus', id, enrollment);
    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.put<Enrollment>(`${this.apiUrl}/api/enrollment/${id}`, enrollment, { headers });
  }

getEnrolledCourses(userId: string): Observable<Enrollment[]> {
    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<Enrollment[]>(`${this.apiUrl}/api/enrollment/user/${userId}`, { headers });
}

enrollCourse(courseId: string, userId: string): Observable<Enrollment> {
  const headers = new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  });
  const body = {
    courseId: courseId,
    userId: userId,
    time: new Date(),
    status: 'Pending'
  };
  return this.http.post<Enrollment>(`${this.apiUrl}/api/enrollment`, body, { headers });
}

// enrollment.service.ts

unenrollCourse(enrollmentId: string): Observable<Enrollment> {
  console.log('unenrollCourse', enrollmentId);
  const headers = new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  });
  return this.http.delete<Enrollment>(`${this.apiUrl}/api/enrollment/${enrollmentId}`, { headers });
}
}
