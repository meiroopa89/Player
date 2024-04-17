import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DoctorService } from '../services/doctor.service';
import { DoctorListComponent } from './doctor-list.component';
import { of } from 'rxjs';

describe('DoctorListComponent', () => {
    let component: DoctorListComponent;
    let fixture: ComponentFixture<DoctorListComponent>;
    let mockDoctorService;

    beforeEach(async () => {
        mockDoctorService = jasmine.createSpyObj(['getDoctors']);

        await TestBed.configureTestingModule({
            declarations: [DoctorListComponent],
            providers: [
                { provide: DoctorService, useValue: mockDoctorService }
            ]
        }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(DoctorListComponent);
        component = fixture.componentInstance;
    });

    fit('should_create_DoctorListComponent', () => {
        mockDoctorService.getDoctors.and.returnValue(of([]));
        fixture.detectChanges();
        expect(component).toBeTruthy();
    });

    fit('DoctorListComponent_should_call_loadDoctors_on_ngOnInit', () => {
        spyOn(component, 'loadDoctors');
        fixture.detectChanges();
        expect(component.loadDoctors).toHaveBeenCalled();
    });

});
