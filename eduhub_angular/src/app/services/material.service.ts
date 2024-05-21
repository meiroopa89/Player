import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { apiUrl } from 'src/apiconfig';
import { Material } from '../models/material.model';


@Injectable({
  providedIn: 'root'
})
export class MaterialService {
  public apiUrl = apiUrl;

  constructor(private http: HttpClient) { }


  getMaterialsByCourseId(courseId: string): Observable<Material[]> {
    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    });
    return this.http.get<Material[]>(`${this.apiUrl}/api/material/course/${courseId}`, { headers });
  }

  addMaterial(material: Material): Observable<Material> {
    console.log("request",material);
    const headers = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token'),
      'Content-Type': 'application/json'
    });
    return this.http.post<Material>(`${this.apiUrl}/api/material`, material, { headers });
  }


deleteMaterial(materialId: number): Observable<any> {
  const headers = new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token'),
    'Content-Type': 'application/json'
  });
  return this.http.delete(`${this.apiUrl}/api/material/${materialId}`, { headers });
}

}
