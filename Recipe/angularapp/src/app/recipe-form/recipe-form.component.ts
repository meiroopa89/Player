import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../services/recipe.service';
import { Router } from '@angular/router';
import { Recipe } from '../models/recipe.model';

@Component({
  selector: 'app-recipe-form',
  templateUrl: './recipe-form.component.html',
  styleUrls: ['./recipe-form.component.css']
})
export class RecipeFormComponent{

  newRecipe: Recipe = {

      Id: 0,
      Name: '',
      Ingredients: ''
  };

  constructor(private recipeService: RecipeService, private router: Router) { }

    addRecipe(): void
    {
      this.recipeService.addRecipe(this.newRecipe).subscribe(() =>

      this.router.navigate(['/viewRecipes'])
      );
    }
}
