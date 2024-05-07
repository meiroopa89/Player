import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { Doctor } from '../models/doctor.model'; // Import Doctor model
import { DoctorService } from './doctor.service'; // Import DoctorService

describe('DoctorService', () => { // Change description to DoctorService
  let service: DoctorService; // Change service to DoctorService
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [DoctorService], // Change RecipeService to DoctorService
    });
    service = TestBed.inject(DoctorService); // Change RecipeService to DoctorService
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('DoctorService should be created', () => { // Change fit to it
    expect(service).toBeTruthy();
  });

  fit('DoctorService should add a doctor and return it', () => { // Change fit to it
    const mockDoctor: Doctor = {
      id: 100,
      firstName: 'Test First Name',
      lastName: 'Test Last Name',
      specialization: 'Test Specialization',
      phoneNumber: 'Test Phone Number',
      email: 'test@email.com',
      address: 'Test Address'
    };

    service.addDoctor(mockDoctor).subscribe((doctor) => {
      expect(doctor).toEqual(mockDoctor);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Doctor`); // Adjust the API endpoint
    expect(req.request.method).toBe('POST');
    req.flush(mockDoctor);
  });

  fit('DoctorService should get doctors', () => { // Change fit to it
    const mockDoctors: Doctor[] = [
      {
        id: 100,
        firstName: 'Test First Name',
        lastName: 'Test Last Name',
        specialization: 'Test Specialization',
        phoneNumber: 'Test Phone Number',
        email: 'test@email.com',
        address: 'Test Address'
      }
    ];

    service.getDoctors().subscribe((doctors) => {
      expect(doctors).toEqual(mockDoctors);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Doctor`); // Adjust the API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockDoctors);
  });

  fit('DoctorService should delete doctor', () => { // Change fit to it
    const doctorId = 100;

    service.deleteDoctor(doctorId).subscribe(() => {
      expect().nothing();
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Doctor/${doctorId}`); // Adjust the API endpoint
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });

  fit('DoctorService should get doctor by id', () => { // Change fit to it
    const doctorId = 100;
    const mockDoctor: Doctor = {
      doctorId: doctorId,
      firstName: 'Test First Name',
      lastName: 'Test Last Name',
      specialization: 'Test Specialization',
      phoneNumber: 'Test Phone Number',
      email: 'test@email.com',
      address: 'Test Address'
    } as any;

    service.getDoctor(doctorId).subscribe((doctor) => {
      expect(doctor).toEqual(mockDoctor);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Doctor/${doctorId}`); // Adjust the API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockDoctor);
  });
});
