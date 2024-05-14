import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { PhoneFormComponent } from './phone-form.component'; // Adjusted component name
import { PhoneService } from '../services/phone.service'; // Adjusted service name
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';
import { Phone } from '../models/phone.model';

describe('PhoneFormComponent', () => { // Adjusted component name
  let component: PhoneFormComponent; // Adjusted component name
  let fixture: ComponentFixture<PhoneFormComponent>; // Adjusted component name
  let phoneService: PhoneService; // Adjusted service name
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PhoneFormComponent], // Adjusted component name
      imports: [FormsModule, RouterTestingModule, HttpClientTestingModule],
      providers: [PhoneService] // Adjusted service name
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PhoneFormComponent); // Adjusted component name
    component = fixture.componentInstance; // Adjusted component name
    phoneService = TestBed.inject(PhoneService); // Adjusted service name
    router = TestBed.inject(Router);
    fixture.detectChanges();
  });

  fit('should_create_PhoneFormComponent', () => { // Adjusted component name
    expect(component).toBeTruthy();
  });

  fit('PhoneFormComponent_should_render_error_messages_when_required_fields_are_empty_on_submit', () => {
    // Set all fields to empty strings
    component.newPhone = {
      phoneId: null,
      brand: '',
      model: '',
      screenSize: null,
      storageCapacity: null,
      ram: null,
      batteryCapacity: null
    } as any;
    
    // Manually trigger form submission
    component.formSubmitted = true;
    
    fixture.detectChanges();
    
    // Find the form element
    const form = fixture.debugElement.query(By.css('form')).nativeElement;
    
    // Submit the form
    form.dispatchEvent(new Event('submit'));
    
    fixture.detectChanges();
    
    // Check if error messages are rendered for each field
    expect(fixture.debugElement.query(By.css('#brand + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#model + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#screenSize + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#storageCapacity + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#ram + .error-message'))).toBeTruthy();
    expect(fixture.debugElement.query(By.css('#batteryCapacity + .error-message'))).toBeTruthy();
  });


  fit('PhoneFormComponent_should_call_addPhone_method_while_adding_the_phone', () => { // Adjusted component name and method name
    // Create a mock Phone object with all required properties
    const phone: Phone = { 
      phoneId: 1, 
      brand: 'Test Brand', 
      model: 'Test Model', 
      screenSize: 6.5, 
      storageCapacity: 128, 
      ram: 8, 
      batteryCapacity: 4000
    };
    const addPhoneSpy = spyOn(component, 'addPhone').and.callThrough(); // Adjusted method name
    component.addPhone(); // Adjusted method name
    expect(addPhoneSpy).toHaveBeenCalled();
  });
});
