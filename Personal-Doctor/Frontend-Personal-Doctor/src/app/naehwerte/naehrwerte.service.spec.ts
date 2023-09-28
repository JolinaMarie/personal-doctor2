import { TestBed } from '@angular/core/testing';

import { NaehrwerteService } from './naehrwerte.service';

describe('NaehrwerteService', () => {
  let service: NaehrwerteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NaehrwerteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
