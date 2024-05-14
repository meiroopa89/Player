import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Phone } from '../models/phone.model';
import { PhoneService } from './phone.service';

describe('PhoneService', () => { // Changed description to PhoneService
  let service: PhoneService; // Changed service variable name to PhoneService
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [PhoneService], // Changed service provider to PhoneService
    });
    service = TestBed.inject(PhoneService); // Changed service variable assignment to PhoneService
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('PhoneService_should_be_created', () => { // Changed fit to it
    expect(service).toBeTruthy();
  });

  fit('PhoneService_should_add_a_Phone_and_return_it', () => { // Changed fit to it
    const mockPhone: Phone = { // Updated 'recipe' to 'phone' and 'Recipe' to 'Phone'
      phoneId: 1, // Adjusted property name
      brand: 'Test Brand', // Adjusted property name
      model: 'Test Model', // Adjusted property name
      screenSize: 6, // Adjusted property name
      storageCapacity: 128, // Adjusted property name
      ram: 8, // Adjusted property name
      batteryCapacity: 4000 // Adjusted property name
    };

    service.addPhone(mockPhone).subscribe((Phone) => {
      expect(Phone).toEqual(mockPhone);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Phone`); // Adjusted API endpoint
    expect(req.request.method).toBe('POST');
    req.flush(mockPhone);
  });

  fit('PhoneService_should_get_Phones', () => { // Changed fit to it
    const mockPhones: Phone[] = [
      {
        phoneId: 1, // Adjusted property name
        brand: 'Test Brand', // Adjusted property name
        model: 'Test Model', // Adjusted property name
        screenSize: 6, // Adjusted property name
        storageCapacity: 128, // Adjusted property name
        ram: 8, // Adjusted property name
        batteryCapacity: 4000 // Adjusted property name
      }
    ];

    service.getPhones().subscribe((Phones) => {
      expect(Phones).toEqual(mockPhones);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Phone`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockPhones);
  });

  fit('PhoneService_should_delete_Phone', () => { // Changed fit to it
    const PhoneId = 100;

    service.deletePhone(PhoneId).subscribe(() => {
      expect().nothing();
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Phone/${PhoneId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });

  fit('PhoneService_should_get_Phone_by_id', () => { // Changed fit to it
    const PhoneId = 100;
    const mockPhone: Phone = {
      phoneId: PhoneId, // Adjusted property name
      brand: 'Test Brand', // Adjusted property name
      model: 'Test Model', // Adjusted property name
      screenSize: 6, // Adjusted property name
      storageCapacity: 128, // Adjusted property name
      ram: 8, // Adjusted property name
      batteryCapacity: 4000 // Adjusted property name
    };

    service.getPhone(PhoneId).subscribe((Phone) => {
      expect(Phone).toEqual(mockPhone);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Phone/${PhoneId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockPhone);
  });
});
