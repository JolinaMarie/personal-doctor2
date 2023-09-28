import { TestBed } from '@angular/core/testing';

import { MeinArztService } from './mein-arzt.service';

describe('MeinArztService', () => {
  let service: MeinArztService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MeinArztService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
