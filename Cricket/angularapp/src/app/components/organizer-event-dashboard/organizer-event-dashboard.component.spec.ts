import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganizerEventDashboardComponent } from './organizer-event-dashboard.component';

describe('OrganizerEventDashboardComponent', () => {
  let component: OrganizerEventDashboardComponent;
  let fixture: ComponentFixture<OrganizerEventDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrganizerEventDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganizerEventDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
