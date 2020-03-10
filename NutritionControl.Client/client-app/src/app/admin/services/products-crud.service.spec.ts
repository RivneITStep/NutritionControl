import { TestBed } from '@angular/core/testing';

import { ProductsCrudService } from './products-crud.service';

describe('ProductsCrudService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProductsCrudService = TestBed.get(ProductsCrudService);
    expect(service).toBeTruthy();
  });
});
