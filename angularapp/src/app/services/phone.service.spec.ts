import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { CarService } from './car.service'; // Adjusted service import
import { Car } from '../models/phone.model';

describe('CarService', () => { // Changed description to CarService
  let service: CarService; // Changed service variable name to CarService
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CarService], // Changed service provider to CarService
    });
    service = TestBed.inject(CarService); // Changed service variable assignment to CarService
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('CarService_should_be_created', () => { // Changed fit to it
    expect(service).toBeTruthy();
  });

  fit('CarService_should_add_a_car_and_return_it', () => { // Changed fit to it
    const mockCar: Car = {
      id: 100,
      make: 'Test Make',
      model: 'Test Model',
      year: 'Test Year',
      color: 'Test Color',
      mileage: 10000,
      price: 5000
    };

    service.addCar(mockCar).subscribe((car) => {
      expect(car).toEqual(mockCar);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Car`); // Adjusted API endpoint
    expect(req.request.method).toBe('POST');
    req.flush(mockCar);
  });

  fit('CarService_should_get_cars', () => { // Changed fit to it
    const mockCars: Car[] = [
      {
        id: 100,
        make: 'Test Make',
        model: 'Test Model',
        year: 'Test Year',
        color: 'Test Color',
        mileage: 10000,
        price: 5000
      }
    ];

    service.getCars().subscribe((cars) => {
      expect(cars).toEqual(mockCars);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Car`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockCars);
  });

  fit('CarService_should_delete_car', () => { // Changed fit to it
    const carId = 100;

    service.deleteCar(carId).subscribe(() => {
      expect().nothing();
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Car/${carId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });

  fit('CarService_should_get_car_by_id', () => { // Changed fit to it
    const carId = 100;
    const mockCar: Car = {
      id: carId,
      make: 'Test Make',
      model: 'Test Model',
      year: 'Test Year',
      color: 'Test Color',
      mileage: 10000,
      price: 5000
    };

    service.getCar(carId).subscribe((car) => {
      expect(car).toEqual(mockCar);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}api/Car/${carId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockCar);
  });
});
