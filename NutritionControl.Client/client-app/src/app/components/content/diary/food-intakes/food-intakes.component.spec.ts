import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodIntakesComponent } from './food-intakes.component';

describe('FoodIntakesComponent', () => {
  let component: FoodIntakesComponent;
  let fixture: ComponentFixture<FoodIntakesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoodIntakesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoodIntakesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
