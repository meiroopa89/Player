import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Fitness } from '../models/fitness.model'; // Adjusted import
import { FitnessService } from './fitness.service'; // Adjusted import

describe('FitnessService', () => { // Changed description to FitnessService
  let service: FitnessService; // Changed service variable name to FitnessService
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [FitnessService], // Changed service provider to FitnessService
    });
    service = TestBed.inject(FitnessService); // Changed service variable assignment to FitnessService
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  fit('FitnessService_should_be_created', () => { // Changed fit to it and updated test description
    expect(service).toBeTruthy();
  });

  fit('FitnessService_should_add_a_Fitness_class_and_return_it', () => { // Changed fit to it and updated test description
    const mockFitness: Fitness = {
      fitnessId: 1,
      className: 'Yoga Class',
      instructorName: 'John Doe',
      classDate: '2024-05-15',
      duration: 60,
      location: 'Fitness Center'
    };

    service.addFitnessClass(mockFitness).subscribe((fitnessClass) => { // Changed addBus to addFitnessClass and adjusted callback parameter
      expect(fitnessClass).toEqual(mockFitness);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Fitness`); // Adjusted API endpoint
    expect(req.request.method).toBe('POST');
    req.flush(mockFitness);
  });

  fit('FitnessService_should_get_Fitness_classes', () => { // Changed fit to it and updated test description
    const mockFitnessClasses: Fitness[] = [
      {
        fitnessId: 1,
        className: 'Yoga Class',
        instructorName: 'John Doe',
        classDate: '2024-05-15',
        duration: 60,
        location: 'Fitness Center'
      }
    ];

    service.getFitnessClasses().subscribe((fitnessClasses) => { // Changed getBuses to getFitnessClasses and adjusted callback parameter
      expect(fitnessClasses).toEqual(mockFitnessClasses);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Fitness`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockFitnessClasses);
  });

  fit('FitnessService_should_delete_a_Fitness_class', () => { // Changed fit to it and updated test description
    const fitnessId = 100;

    service.deleteFitnessClass(fitnessId).subscribe(() => {
      expect().nothing();
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Fitness/${fitnessId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('DELETE');
    req.flush({});
  });

  fit('FitnessService_should_get_a_Fitness_class_by_id', () => { // Changed fit to it and updated test description
    const fitnessId = 100;
    const mockFitness: Fitness = {
      fitnessId: fitnessId,
      className: 'Yoga Class',
      instructorName: 'John Doe',
      classDate: '2024-05-15',
      duration: 60,
      location: 'Fitness Center'
    };

    service.getFitnessClass(fitnessId).subscribe((fitnessClass) => { // Changed getBus to getFitnessClass and adjusted callback parameter
      expect(fitnessClass).toEqual(mockFitness);
    });

    const req = httpTestingController.expectOne(`${service['apiUrl']}/api/Fitness/${fitnessId}`); // Adjusted API endpoint
    expect(req.request.method).toBe('GET');
    req.flush(mockFitness);
  });
});
