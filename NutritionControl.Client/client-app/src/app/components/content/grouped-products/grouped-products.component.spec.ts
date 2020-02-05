import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupedProductsComponent } from './grouped-products.component';

describe('GroupedProductsComponent', () => {
  let component: GroupedProductsComponent;
  let fixture: ComponentFixture<GroupedProductsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupedProductsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupedProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
