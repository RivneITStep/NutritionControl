import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoriesCrudComponent } from './categories-crud.component';

describe('CategoriesCrudComponent', () => {
  let component: CategoriesCrudComponent;
  let fixture: ComponentFixture<CategoriesCrudComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoriesCrudComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoriesCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
