import { TestBed } from '@angular/core/testing';

import { ManagmentService } from './managment.service';

describe('ManagmentService', () => {
  let service: ManagmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ManagmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
