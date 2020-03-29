import { TestBed, async, inject } from '@angular/core/testing';

import { DiaryGuard } from './diary.guard';

describe('DiaryGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DiaryGuard]
    });
  });

  it('should ...', inject([DiaryGuard], (guard: DiaryGuard) => {
    expect(guard).toBeTruthy();
  }));
});
