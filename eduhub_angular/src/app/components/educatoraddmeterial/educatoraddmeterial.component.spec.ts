import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EducatoraddmeterialComponent } from './educatoraddmeterial.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
describe('EducatoraddmeterialComponent', () => {
  let component: EducatoraddmeterialComponent;
  let fixture: ComponentFixture<EducatoraddmeterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, RouterTestingModule, HttpClientTestingModule, FormsModule],
      declarations: [ EducatoraddmeterialComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EducatoraddmeterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  fit('Frontend_should_create_educatoraddmaterial_component', () => {
    expect(component).toBeTruthy();
  });
  fit('Frontend_should_contain_add_material_heading_in_the_educatoraddmaterial_component', () => {
    const componentHTML = fixture.debugElement.nativeElement.outerHTML;
    expect(componentHTML).toContain('Add Material');
  });
  fit('Frontend_should_contain_title_in_the_educatoraddmaterial_component', () => {
    const componentHTML = fixture.debugElement.nativeElement.outerHTML;
    expect(componentHTML).toContain('Title');
  });
});
