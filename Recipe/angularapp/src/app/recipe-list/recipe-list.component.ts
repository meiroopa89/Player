import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../services/recipe.service';
import { Router } from '@angular/router';
import { Recipe } from '../models/recipe.model';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit {

  recipe: Recipe[] = [];
  constructor(private recipeService: RecipeService, private router: Router) { }

  ngOnInit(): void {
    this.loadRecipe();
  }

  loadRecipe(): void {
    this.recipeService.getRecipe(). subscribe(recipe => this.recipe = recipe);
  }

}
