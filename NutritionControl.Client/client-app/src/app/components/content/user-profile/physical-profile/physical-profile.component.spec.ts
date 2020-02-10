import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhysicalProfileComponent } from './physical-profile.component';

describe('PhysicalProfileComponent', () => {
  let component: PhysicalProfileComponent;
  let fixture: ComponentFixture<PhysicalProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhysicalProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhysicalProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
