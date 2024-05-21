import { TestBed } from '@angular/core/testing';

import { MaterialService } from './material.service';

describe('MaterialService', () => {
  let service: MaterialService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaterialService);
  });

  it('Frontend_should_create_material_service', () => {
    expect(service).toBeTruthy();
  });
});
