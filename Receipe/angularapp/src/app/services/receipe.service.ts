// src/app/services/recipe.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Recipe } from '../models/receipe.model';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  private apiUrl = 'https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/'; // Replace this with your API endpoint

  constructor(private http: HttpClient) { }

  addRecipe(recipe: Recipe): Observable<Recipe> {
    return this.http.post<Recipe>(this.apiUrl, recipe);
  }
}
