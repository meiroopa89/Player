import { TestBed } from '@angular/core/testing';



describe('ReceipeService', () => {
  let service: ReceipeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReceipeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
