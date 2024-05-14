import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { PhoneService } from '../services/Phone.service'; // Import PhoneService
import { PhoneListComponent } from './Phone-list.component'; // Adjust the import path
import { of } from 'rxjs';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Phone } from '../models/phone.model'; // Import Phone model

describe('PhoneListComponent', () => {
    let component: PhoneListComponent;
    let fixture: ComponentFixture<PhoneListComponent>;
    let mockPhoneService: jasmine.SpyObj<PhoneService>; // Specify the type of mock

    beforeEach(waitForAsync(() => {
        // Create a spy object with the methods you want to mock
        mockPhoneService = jasmine.createSpyObj<PhoneService>('PhoneService', ['getPhones', 'deletePhone'] as any);

        TestBed.configureTestingModule({
            declarations: [PhoneListComponent],
            imports: [RouterTestingModule, HttpClientTestingModule],
            providers: [
                // Provide the mock service instead of the actual service
                { provide: PhoneService, useValue: mockPhoneService }
            ]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(PhoneListComponent);
        component = fixture.componentInstance;
    });

    fit('should_create_PhoneListComponent', () => { // Change the function name
        expect(component).toBeTruthy();
    });

    fit('PhoneListComponent_should_call_loadPhones_on_ngOnInit', () => { // Change the function name
        spyOn(component, 'loadPhones'); // Adjust the method name
        fixture.detectChanges();
        expect(component.loadPhones).toHaveBeenCalled(); // Adjust the method name
    });

});
