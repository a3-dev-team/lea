import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectifDetailComponent } from './objectif-detail.component';

describe('ObjectifDetailComponent', () => {
  let component: ObjectifDetailComponent;
  let fixture: ComponentFixture<ObjectifDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObjectifDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjectifDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
