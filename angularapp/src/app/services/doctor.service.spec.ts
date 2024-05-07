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
      providers: [DoctorService], // Change DoctorService to DoctorService
    });
    service = TestBed.inject(DoctorService); // Change DoctorService to DoctorService
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('DoctorService_should_be_created', () => { // Change fit to it
    expect(service).toBeTruthy();
  });

  fit('DoctorService_should_add_a_doctor_and_return_it', () => { // Change fit to it
    const mockDoctor: Doctor = {
      id: 100,
      firstName: 'Test First Name',
      lastName: 'Test Last Name',
      specialization: 'Test Specialization',
      phoneNumber: 'Test Phone Number',
      email: 'test@email.com',
      address: 'Test Address'
    } as any;

    service.addDoctor(mockDoctor).subscribe((doctor) => {
      expect(doctor).toEqual(mockDoctor);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Doctor`); // Adjust the API endpoint
    expect(req.request.method).toBe('POST');
    req.flush(mockDoctor);
  });

  fit('DoctorService_should_get_doctors', () => { // Change fit to it
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
    ] as any;

    service.getDoctors().subscribe((doctors) => {
      expect(doctors).toEqual(mockDoctors);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Doctor`); // Adjust the API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockDoctors);
  });

  fit('DoctorService_should_delete_doctor', () => { // Change fit to it
    const doctorId = 100;

    service.deleteDoctor(doctorId).subscribe(() => {
      expect().nothing();
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Doctor/${doctorId}`); // Adjust the API endpoint
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });

  fit('DoctorService_should_get_doctor_by_id', () => { // Change fit to it
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
