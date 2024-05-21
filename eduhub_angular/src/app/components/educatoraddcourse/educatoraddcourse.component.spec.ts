import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EducatoraddcourseComponent } from './educatoraddcourse.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('EducatoraddcourseComponent', () => {
  let component: EducatoraddcourseComponent;
  let fixture: ComponentFixture<EducatoraddcourseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, RouterTestingModule, HttpClientTestingModule, FormsModule],
      declarations: [ EducatoraddcourseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EducatoraddcourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  fit('Frontend_should_create_educatoraddcourse_component', () => {
    expect(component).toBeTruthy();
  });
  fit('Frontend_should_contain_create_new_course_heading_in_the_educatoraddcourse_component', () => {
    const componentHTML = fixture.debugElement.nativeElement.outerHTML;
    expect(componentHTML).toContain('Create New Course');
  });
  fit('Frontend_should_contain_course_title_in_the_educatoraddcourse_component', () => {
    const componentHTML = fixture.debugElement.nativeElement.outerHTML;
    expect(componentHTML).toContain('Course Title');
  });
});
