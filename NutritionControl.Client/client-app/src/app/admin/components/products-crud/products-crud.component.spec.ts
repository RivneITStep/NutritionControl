import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsCrudComponent } from './products-crud.component';

describe('ProductsCrudComponent', () => {
  let component: ProductsCrudComponent;
  let fixture: ComponentFixture<ProductsCrudComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductsCrudComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductsCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
