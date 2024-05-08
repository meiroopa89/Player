import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  private apiUrl = "";
  constructor(private http: HttpClient) { }

  addRecipe(Recipe: Recipe): Observable<Recipe>
  {
    return this.http.post<Recipe>(`${this.apiUrl}api/R`)
  }
}
