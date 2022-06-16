import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectifEleveTileListComponent } from './objectif-eleve-tile-list.component';

describe('ObjectifEleveTileListComponent', () => {
  let component: ObjectifEleveTileListComponent;
  let fixture: ComponentFixture<ObjectifEleveTileListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObjectifEleveTileListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjectifEleveTileListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
