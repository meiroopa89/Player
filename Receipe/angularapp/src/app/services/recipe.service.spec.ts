import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { Recipe } from '../models/recipe.model';
import { RecipeService } from './recipe.service';

describe('RecipeService', () => {
  let service: RecipeService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [RecipeService],
    });
    service = TestBed.inject(RecipeService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('RecipeService_should be created', () => {
    expect(service).toBeTruthy();
  });

  it('RecipeService_should have addRecipe method', () => {
    expect(service.addRecipe).toBeTruthy();
  });

  it('RecipeService_should have getRecipes method', () => {
    expect(service.getRecipes).toBeTruthy();
  });

  fit('RecipeService_should_add_a_recipe and return it', () => {
    const mockRecipe: Recipe = {
      recipeId: 1,
      name: 'Test Recipe',
      description: 'Test Description',
      ingredients: 'Test Ingredients',
      instructions: 'Test Instructions',
      author: 'Test Author'
    };

    service.addRecipe(mockRecipe).subscribe((recipe) => {
      expect(recipe).toEqual(mockRecipe);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Recipe`);
    expect(req.request.method).toBe('POST');
    req.flush(mockRecipe);
  });

  fit('RecipeService_should_get_recipes', () => {
    const mockRecipes: Recipe[] = [
      {
        recipeId: 1,
        name: 'Test Recipe 1',
        description: 'Test Description',
        ingredients: 'Test Ingredients',
        instructions: 'Test Instructions',
        author: 'Test Author'
      }
    ];

    service.getRecipes().subscribe((recipes) => {
      expect(recipes).toEqual(mockRecipes);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Recipe`);
    expect(req.request.method).toBe('GET');
    req.flush(mockRecipes);
  });
});
