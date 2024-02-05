import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';


describe('AppComponent', () => {
    let fixture: ComponentFixture<AppComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            imports: [
                RouterTestingModule
            ],
            declarations: [
                AppComponent
            ],
        }).compileComponents();
        fixture = TestBed.createComponent(AppComponent);

    });

    fit('AppComponent_should_render_app-book-form', () => {
        const compiled = fixture.nativeElement;
        expect(compiled.querySelector('app-book-form')).toBeTruthy();
    });

    fit('AppComponent_should_render_app-book-list', () => {
        const compiled = fixture.nativeElement;
        expect(compiled.querySelector('app-book-list')).toBeTruthy();
    });

});
