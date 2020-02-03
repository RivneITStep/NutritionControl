import { TestBed } from '@angular/core/testing';

import { JwtTokenService } from './jwt-token.service';

describe('JwtTokenService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: JwtTokenService = TestBed.get(JwtTokenService);
    expect(service).toBeTruthy();
  });
});
