// src/app/recipe-form/recipe-form.component.ts
import { Component } from '@angular/core';
import { Recipe } from '../models/receipe.model';
import { RecipeService } from '../services/receipe.service'; // Corrected import statement

@Component({
  selector: 'app-recipe-form',
  templateUrl: './recipe-form.html',
  styleUrls: ['./recipe-form.css']
})
export class RecipeFormComponent {
  newRecipe: Recipe = {
    recipeId: 0,
    name: '',
    description: '',
    ingredients: '',
    instructions: '',
    author: ''
  };

  constructor(private recipeService: RecipeService) { } // Corrected constructor parameter

  addRecipe(): void {
    this.recipeService.addRecipe(this.newRecipe).subscribe(() => {
      console.log('Recipe added successfully!');
    });
  }
}
