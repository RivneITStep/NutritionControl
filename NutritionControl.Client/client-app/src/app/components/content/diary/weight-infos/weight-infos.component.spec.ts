import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WeightInfosComponent } from './weight-infos.component';

describe('WeightInfosComponent', () => {
  let component: WeightInfosComponent;
  let fixture: ComponentFixture<WeightInfosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WeightInfosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WeightInfosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
