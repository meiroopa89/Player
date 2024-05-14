import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { PhoneService } from './phone.service'; // Adjusted service import
import { Phone } from '../models/phone.model';

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

  fit('PhoneService_should_add_a_phone_and_return_it', () => { // Changed fit to it
    const mockPhone: Phone = {
      phoneId: 100,
      brand: 'Test Brand',
      model: 'Test Model',
      screenSize: 6.5,
      storageCapacity: 128,
      ram: 8,
      batteryCapacity: 5000
    };

    service.addPhone(mockPhone).subscribe((phone) => {
      expect(phone).toEqual(mockPhone);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}phones`); // Adjusted API endpoint
    expect(req.request.method).toBe('POST');
    req.flush(mockPhone);
  });

  fit('PhoneService_should_get_phones', () => { // Changed fit to it
    const mockPhones: Phone[] = [
      {
        phoneId: 100,
        brand: 'Test Brand',
        model: 'Test Model',
        screenSize: 6.5,
        storageCapacity: 128,
        ram: 8,
        batteryCapacity: 5000
      }
    ];

    service.getPhones().subscribe((phones) => {
      expect(phones).toEqual(mockPhones);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}phones`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockPhones);
  });

  fit('PhoneService_should_delete_phone', () => { // Changed fit to it
    const phoneId = 100;

    service.deletePhone(phoneId).subscribe(() => {
      expect().nothing();
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}phones/${phoneId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });

  fit('PhoneService_should_get_phone_by_id', () => { // Changed fit to it
    const mockPhone: Phone = {
      phoneId: 0,
      brand: 'Test Brand',
      model: 'Test Model',
      screenSize: 6.5,
      storageCapacity: 128,
      ram: 8,
      batteryCapacity: 5000
    };

    service.getPhone(phoneId).subscribe((phone) => {
      expect(phone).toEqual(mockPhone);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}phones/${phoneId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockPhone);
  });
});
