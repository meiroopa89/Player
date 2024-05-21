import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MycourseComponent } from './mycourse.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
describe('MycourseComponent', () => {
  let component: MycourseComponent;
  let fixture: ComponentFixture<MycourseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, RouterTestingModule, HttpClientTestingModule, FormsModule],

      declarations: [ MycourseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MycourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  fit('Frontend_should_create_mycourse_component', () => {
    expect(component).toBeTruthy();
  });

  fit('Frontend_should_contain_my_courses_heading_in_the_mycourse_component', () => {
    const componentHTML = fixture.debugElement.nativeElement.outerHTML;
    expect(componentHTML).toContain('My Courses');
  });
});
