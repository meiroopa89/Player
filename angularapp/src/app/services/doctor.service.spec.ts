import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { Doctor } from '../models/doctor.model';
import { DoctorService } from './doctor.service';

describe('DoctorService', () => {
  let service: DoctorService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [DoctorService],
    });
    service = TestBed.inject(DoctorService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('DoctorService_should_be_created', () => {
    expect(service).toBeTruthy();
  });

  fit('DoctorService_should_have_addDoctor_method', () => {
    expect(service.addDoctor).toBeTruthy();
  });

  fit('DoctorService_should_have_getDoctors_method', () => {
    expect(service.getDoctors).toBeTruthy();
  });

  fit('DoctorService_should_add_a_doctor_and_return_it', () => {
    const mockDoctor: Doctor = {
      id: 1,
      firstName: 'John',
      lastName: 'Doe',
      specialization: 'Cardiologist',
      phoneNumber: '1234567890',
      email: 'john.doe@example.com',
      address: '123 Main St'
    };

    service.addDoctor(mockDoctor).subscribe((doctor) => {
      expect(doctor).toEqual(mockDoctor);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Doctor`);
    expect(req.request.method).toBe('POST');
    req.flush(mockDoctor);
  });

  fit('DoctorService_should_get_doctors', () => {
    const mockDoctors: Doctor[] = [
      {
        id: 1,
        firstName: 'John',
        lastName: 'Doe',
        specialization: 'Cardiologist',
        phoneNumber: '1234567890',
        email: 'john.doe@example.com',
        address: '123 Main St'
      }
    ];

    service.getDoctors().subscribe((doctors) => {
      expect(doctors).toEqual(mockDoctors);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Doctor`);
    expect(req.request.method).toBe('GET');
    req.flush(mockDoctors);
  });
});
