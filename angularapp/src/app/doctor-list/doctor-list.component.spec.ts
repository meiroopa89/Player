import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { RecipeService } from '../services/recipe.service';
import { RecipeListComponent } from './doctor-list.component';
import { of } from 'rxjs';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Recipe } from '../models/doctor.model';

describe('RecipeListComponent', () => {
    let component: RecipeListComponent;
    let fixture: ComponentFixture<RecipeListComponent>;
    let mockRecipeService: jasmine.SpyObj<RecipeService>; // Specify the type of mock

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockRecipeService = jasmine.createSpyObj<RecipeService>('RecipeService', ['getRecipes', 'addRecipe'] as any);

        TestBed.configureTestingModule({
            declarations: [RecipeListComponent],
            imports: [RouterTestingModule, HttpClientTestingModule],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: RecipeService, useValue: mockRecipeService }
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(RecipeListComponent);
        component = fixture.componentInstance;
    });

    fit('should_create_recipe_listComponent', () => {
        expect(component).toBeTruthy();
    });

    fit('recipe_listComponent_should_call_loadRecipes_on_ngOnInit', () => {
        spyOn(component, 'loadRecipes');
        fixture.detectChanges();
        expect(component.loadRecipes).toHaveBeenCalled();
    });

});
