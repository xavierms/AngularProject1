import { TestBed } from '@angular/core/testing';

import { TrabajadoresService } from './trabajadores.service';

describe('TrabajadoresService', () => {
  let service: TrabajadoresService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrabajadoresService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
