import { TestBed } from '@angular/core/testing';

import { CategoriesCrudService } from './categories-crud.service';

describe('CategoriesCrudService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CategoriesCrudService = TestBed.get(CategoriesCrudService);
    expect(service).toBeTruthy();
  });
});
