import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnrollmentlistComponent } from './enrollmentlist.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
describe('EnrollmentlistComponent', () => {
  let component: EnrollmentlistComponent;
  let fixture: ComponentFixture<EnrollmentlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, RouterTestingModule, HttpClientTestingModule, FormsModule],

      declarations: [ EnrollmentlistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EnrollmentlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  fit('Frontend_should_create_enrollmentlist_component', () => {
    expect(component).toBeTruthy();
  });

  fit('Frontend_should_contain_enrollments_heading_in_the_enrollmentlist_component', () => {
    const componentHTML = fixture.debugElement.nativeElement.outerHTML;
    expect(componentHTML).toContain('Enrollments');
  });
});
