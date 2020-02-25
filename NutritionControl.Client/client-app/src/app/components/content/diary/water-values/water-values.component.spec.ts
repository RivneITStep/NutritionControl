import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WaterValuesComponent } from './water-values.component';

describe('WaterValuesComponent', () => {
  let component: WaterValuesComponent;
  let fixture: ComponentFixture<WaterValuesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WaterValuesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WaterValuesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
