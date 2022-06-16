import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectifEleveTileComponent } from './objectif-eleve-tile.component';

describe('ObjectifEleveTileComponent', () => {
  let component: ObjectifEleveTileComponent;
  let fixture: ComponentFixture<ObjectifEleveTileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ObjectifEleveTileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjectifEleveTileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
