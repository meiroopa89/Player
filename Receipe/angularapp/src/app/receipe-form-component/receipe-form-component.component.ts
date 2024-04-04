// src/app/recipe-form/recipe-form.component.ts
import { Component } from '@angular/core';
import { Recipe } from '../models/receipe.model';
import { ReceipeServiceService } from '../services/receipe-service.service';

@Component({
  selector: 'app-recipe-form',
  templateUrl: './recipe-form.component.html',
  styleUrls: ['./recipe-form.component.css']
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

  constructor(private recipeService: ReceipeServiceService) { }

  addRecipe(): void {
    this.recipeService.addRecipe(this.newRecipe).subscribe(() => {
      console.log('Recipe added successfully!');
    });
  }
}
