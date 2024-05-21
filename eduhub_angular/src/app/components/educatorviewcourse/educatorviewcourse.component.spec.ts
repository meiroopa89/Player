import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EducatorviewcourseComponent } from './educatorviewcourse.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
describe('EducatorviewcourseComponent', () => {
  let component: EducatorviewcourseComponent;
  let fixture: ComponentFixture<EducatorviewcourseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, RouterTestingModule, HttpClientTestingModule, FormsModule],
      declarations: [ EducatorviewcourseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EducatorviewcourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  fit('Frontend_should_create_educatorviewcourse_component', () => {
    expect(component).toBeTruthy();
  });
  fit('Frontend_should_contain_courses_heading_in_the_educatorviewcourse_component', () => {
    const componentHTML = fixture.debugElement.nativeElement.outerHTML;
    expect(componentHTML).toContain('Courses');
  });
});
