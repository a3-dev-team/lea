import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParametrageListeObjectifComponent } from './parametrage-liste-objectif.component';

describe('ParametrageListeObjectifComponent', () => {
  let component: ParametrageListeObjectifComponent;
  let fixture: ComponentFixture<ParametrageListeObjectifComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ParametrageListeObjectifComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ParametrageListeObjectifComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
