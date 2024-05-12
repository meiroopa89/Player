import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { combineLatest } from 'rxjs';
import { RecipeFormComponent } from './recipe-form/recipe-form.component';

const routes: Routes = [
  {path: "viewRecipes", component: RecipeListComponent},
  {path: "addRecipe", component: RecipeFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
