import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { DeleteConfirmComponent } from './delete-confirm.component';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { PhoneService } from '../services/flight.service'; // Adjusted service name

describe('DeleteConfirmComponent', () => {
    let component: DeleteConfirmComponent;
    let fixture: ComponentFixture<DeleteConfirmComponent>;
    let router: Router;
    let activatedRoute: ActivatedRoute;
    let mockPhoneService: jasmine.SpyObj<PhoneService>; // Adjusted service name

    beforeEach(waitForAsync(() => {
        mockPhoneService = jasmine.createSpyObj<PhoneService>('PhoneService', ['getPhone', 'deletePhone'] as any); // Adjusted service name and methods

        TestBed.configureTestingModule({
            imports: [RouterTestingModule, HttpClientModule, FormsModule, HttpClientTestingModule],
            declarations: [DeleteConfirmComponent],
            providers: [
                { provide: PhoneService, useValue: mockPhoneService } // Adjusted service name
            ]
        }).compileComponents();
        router = TestBed.inject(Router);
        activatedRoute = TestBed.inject(ActivatedRoute);
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(DeleteConfirmComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    fit('should_create_DeleteConfirmComponent', () => {
        expect(component).toBeTruthy();
    });

    fit('DeleteConfirmComponent_should_call_deletePhone_method_when_confirmDelete_is_called', () => {
        const phoneId = 1; // Adjusted ID name
        
        mockPhoneService.deletePhone.and.returnValue(of(null)); // Adjusted method name

        component.confirmDelete(phoneId); // Adjusted parameter name

        expect(mockPhoneService.deletePhone).toHaveBeenCalledWith(phoneId); // Adjusted method name and parameter
    });
});
