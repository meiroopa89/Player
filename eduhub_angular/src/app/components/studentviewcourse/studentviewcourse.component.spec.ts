import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentviewcourseComponent } from './studentviewcourse.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('StudentviewcourseComponent', () => {
  let component: StudentviewcourseComponent;
  let fixture: ComponentFixture<StudentviewcourseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, RouterTestingModule, HttpClientTestingModule, FormsModule],

      declarations: [ StudentviewcourseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentviewcourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  fit('Frontend_should_create_studentviewcourse_component', () => {
    expect(component).toBeTruthy();
  });
  fit('Frontend_should_contain_available_courses_heading_in_the_studentviewcourse_component', () => {
    const componentHTML = fixture.debugElement.nativeElement.outerHTML;
    expect(componentHTML).toContain('Available Courses');
  });

});
