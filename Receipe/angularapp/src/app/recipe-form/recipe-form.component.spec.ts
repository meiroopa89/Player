import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed, async } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';

import { RecipeService } from '../services/recipe.service';
import { RecipeFormComponent } from './recipe-form.component';
import { Router } from '@angular/router';

describe('RecipeFormComponent', () => {
    let component: RecipeFormComponent;
    let fixture: ComponentFixture<RecipeFormComponent>;
    let recipeService: RecipeService;
    let router: Router;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [FormsModule, HttpClientTestingModule],
            declarations: [RecipeFormComponent],
            providers: [RecipeService, { provide: Router, useClass: class { navigate = jasmine.createSpy('navigate'); } }]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(RecipeFormComponent);
        component = fixture.componentInstance;
        recipeService = TestBed.inject(RecipeService);
        router = TestBed.inject(Router);
    });

    fit('should create RecipeFormComponent', () => {
        expect(component).toBeTruthy();
    });

    fit('RecipeFormComponent_should have a form for adding a recipe', () => {
        const formElement: HTMLFormElement = fixture.nativeElement.querySelector('form');
        expect(formElement).toBeTruthy();
    });

    fit('RecipeFormComponent_should have form controls for recipe details, description, ingredients, instructions, and author', () => {
        const formElement: HTMLFormElement = fixture.nativeElement.querySelector('form');
        expect(formElement.querySelector('#name')).toBeTruthy();
        expect(formElement.querySelector('#description')).toBeTruthy();
        expect(formElement.querySelector('#ingredients')).toBeTruthy();
        expect(formElement.querySelector('#instructions')).toBeTruthy();
        expect(formElement.querySelector('#author')).toBeTruthy();
    });

    fit('RecipeFormComponent_should have a button for adding a recipe', () => {
        const buttonElement: HTMLButtonElement = fixture.nativeElement.querySelector('button');
        expect(buttonElement).toBeTruthy();
        expect(buttonElement.textContent).toContain('Add Recipe');
    });

    fit('RecipeFormComponent_should have addRecipe method', () => {
        expect(component['addRecipe']).toBeTruthy();
    });

    fit('addRecipe method should add recipe and navigate to viewRecipes', () => {
        spyOn(recipeService, 'addRecipe').and.returnValue({ subscribe: () => {} });
        component.addRecipe();
        expect(recipeService.addRecipe).toHaveBeenCalledWith(component.newRecipe);
        expect(router.navigate).toHaveBeenCalledWith(['/viewRecipes']);
    });

});
