import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceipeFormComponentComponent } from './receipe-form-component.component';

describe('ReceipeFormComponentComponent', () => {
  let component: ReceipeFormComponentComponent;
  let fixture: ComponentFixture<ReceipeFormComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceipeFormComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReceipeFormComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
