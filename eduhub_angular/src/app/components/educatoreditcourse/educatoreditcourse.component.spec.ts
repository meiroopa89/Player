import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EducatoreditcourseComponent } from './educatoreditcourse.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('EducatoreditcourseComponent', () => {
  let component: EducatoreditcourseComponent;
  let fixture: ComponentFixture<EducatoreditcourseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, RouterTestingModule, HttpClientTestingModule, FormsModule],
      declarations: [ EducatoreditcourseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EducatoreditcourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

 
});
