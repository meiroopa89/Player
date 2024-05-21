import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/apiconfig';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  public apiUrl = apiUrl; // Update with your API URL

  constructor(private http: HttpClient) { }

  getAllCourses(): Observable<Course[]> {
    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<Course[]>(`${this.apiUrl}/api/course`, { headers });
  }

  deleteCourse(courseId: string): Observable<void> {
    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.delete<void>(`${this.apiUrl}/api/course/${courseId}`, { headers });
  }

  getCourseById(id: string): Observable<Course> {
    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<Course>(`${this.apiUrl}/api/course/${id}`, { headers });
  }

  addCourse(requestObject: Course): Observable<Course> {
    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.post<Course>(`${this.apiUrl}/api/course`, requestObject, { headers });
  }

  updateCourse(id: string, requestObject: Course): Observable<Course> {
    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.put<Course>(`${this.apiUrl}/api/course/${id}`, requestObject, { headers });
  }
}
