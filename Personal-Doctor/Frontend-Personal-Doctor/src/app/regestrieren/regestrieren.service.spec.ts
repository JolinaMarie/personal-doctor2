import { TestBed } from '@angular/core/testing';

import { RegestrierenService } from './regestrieren.service';

describe('RegestrierenService', () => {
  let service: RegestrierenService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegestrierenService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
