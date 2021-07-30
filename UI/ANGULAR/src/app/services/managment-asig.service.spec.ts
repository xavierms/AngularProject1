import { TestBed } from '@angular/core/testing';

import { ManagmentAsigService } from './managment-asig.service';

describe('ManagmentAsigService', () => {
  let service: ManagmentAsigService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ManagmentAsigService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
