import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { Router } from '@angular/router';
import { HeaderComponent } from './header.component';

describe('HeaderComponent', () => {
    let component: HeaderComponent;
    let fixture: ComponentFixture<HeaderComponent>;
    let router: Router;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [HeaderComponent],
            imports: [RouterTestingModule],
        }).compileComponents();

        fixture = TestBed.createComponent(HeaderComponent);
        component = fixture.componentInstance;
        router = TestBed.inject(Router);
    });

    fit('should create HeaderComponent', () => {
        expect(component).toBeTruthy();
    });

    fit('HeaderComponent_should navigate to Add New Recipe', () => {
        spyOn(router, 'navigate');
        component.navigateToAddRecipe();
        expect(router.navigate).toHaveBeenCalledWith(['/addNewRecipe']);
    });

    fit('HeaderComponent_should navigate to View Recipe', () => {
        spyOn(router, 'navigate');
        component.navigateToViewRecipes();
        expect(router.navigate).toHaveBeenCalledWith(['/viewRecipes']);
    });

    fit('HeaderComponent_should have Recipe Sharing Platform as the brand', () => {
        const brandElement: HTMLElement = fixture.nativeElement.querySelector('h1');
        expect(brandElement.textContent).toContain('Recipe Sharing Platform');
    });

    fit('HeaderComponent_should have a link with text View Recipe', () => {
        const navItems: NodeListOf<HTMLElement> = fixture.nativeElement.querySelectorAll('a');
        const viewRecipeLink: HTMLElement = navItems[navItems.length - 1];
        expect(viewRecipeLink.textContent).toContain('View Recipe');
    });
});
