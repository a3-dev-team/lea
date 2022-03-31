import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectifListeComponent } from './objectif-liste.component';

describe('ObjectifListeComponent', () => {
  let component: ObjectifListeComponent;
  let fixture: ComponentFixture<ObjectifListeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObjectifListeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjectifListeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
