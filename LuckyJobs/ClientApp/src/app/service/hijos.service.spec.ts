import { TestBed } from '@angular/core/testing';

import { HijoService } from './hijos.service';

describe('HijoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HijoService = TestBed.get(HijoService);
    expect(service).toBeTruthy();
  });
});
