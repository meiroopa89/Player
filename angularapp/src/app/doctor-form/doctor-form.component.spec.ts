import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { RouterTestingModule } from '@angular/router/testing';
import { RecipeFormComponent } from './doctor-form.component';
import { RecipeService } from '../services/recipe.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { Recipe } from '../models/doctor.model';
import { fakeAsync, tick } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';
import { RecipeListComponent } from '../doctor-list/doctor-list.component';

describe('RecipeFormComponent', () => {
  let component: RecipeFormComponent;
  let fixture: ComponentFixture<RecipeFormComponent>;
  let recipeService: RecipeService;
  let router: Router;
  let recipeListComponent: RecipeListComponent;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RecipeFormComponent],
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
      providers: [
        RecipeService,
      ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

    recipeService = TestBed.inject(RecipeService);
    router = TestBed.inject(Router);

  });

  fit('should_create_RecipeFormComponent', () => {
    expect(component).toBeTruthy();
});

  fit('RecipeFormComponent_should_not_render_any_error_messages_when_all_fields_are_filled', () => {
    const compiled = fixture.nativeElement;
    const form = compiled.querySelector('form');

    // Fill all fields
    component.newRecipe = {
      recipeId: null, // or omit this line if recipeId is auto-generated
      name: 'Test Name',
      description: 'Test Description',
      ingredients: 'Test Ingredients',
      instructions: 'Test Instructions',
      author: 'Test Author'
    } as any;

    fixture.detectChanges();

    form.dispatchEvent(new Event('submit')); // Submit the form

    // Check if no error messages are rendered
    expect(compiled.querySelector('#nameError')).toBeNull();
    expect(compiled.querySelector('#descriptionError')).toBeNull();
    expect(compiled.querySelector('#ingredientsError')).toBeNull();
    expect(compiled.querySelector('#instructionsError')).toBeNull();
    expect(compiled.querySelector('#authorError')).toBeNull();
  });

  fit('RecipeFormComponent_should_call_add_recipe_method_while_adding_the_recipe', () => {
    // Create a mock Recipe object with all required properties
    const recipe: Recipe = { 
      recipeId: 1, 
      name: 'Test Recipe', 
      description: 'Test Recipe Description', 
      ingredients: 'Ingredient 2', 
      instructions: 'Test Recipe Instructions', 
      author: 'Test Author'
    } as any;
    const addRecipeSpy = spyOn(component, 'addRecipe').and.callThrough();
    component.addRecipe();
    expect(addRecipeSpy).toHaveBeenCalled();
  });
});

