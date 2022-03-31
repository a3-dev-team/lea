import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectionEleveComponent } from './selection-eleve.component';

describe('SelectionEleveComponent', () => {
  let component: SelectionEleveComponent;
  let fixture: ComponentFixture<SelectionEleveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectionEleveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectionEleveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
