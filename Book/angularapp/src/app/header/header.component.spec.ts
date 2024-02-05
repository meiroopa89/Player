import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { HeaderComponent } from './header.component';

describe('HeaderComponent', () => {
    let component: HeaderComponent;
    let fixture: ComponentFixture<HeaderComponent>;
    let router: Router;

    beforeEach(() => {
        TestBed.configureTestingModule({
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

    fit('HeaderComponent_should navigate to Add New Book', () => {
        spyOn(router, 'navigate');
        component['navigateToAddBook']();
        expect(router.navigate).toHaveBeenCalledWith(['/addNewBook']);
    });

    fit('HeaderComponent_should navigate to View Books', () => {
        spyOn(router, 'navigate');
        component['navigateToViewBooks']();
        expect(router.navigate).toHaveBeenCalledWith(['/viewBooks']);
    });


    fit('HeaderComponent_should have Bookstore as the brand', () => {
        const brandElement: HTMLElement = fixture.nativeElement.querySelector('h1');
        expect(brandElement.textContent).toContain('Bookstore');
    });

    fit('HeaderComponent_should have a link with text View Books', () => {
        const navItems: NodeListOf<HTMLElement> = fixture.nativeElement.querySelectorAll('a');
        const viewBooksLink: HTMLElement = navItems[navItems.length - 1];
        expect(viewBooksLink.textContent).toContain('View Books');
    });
});