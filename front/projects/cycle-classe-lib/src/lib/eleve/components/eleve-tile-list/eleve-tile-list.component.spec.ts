import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EleveTileListComponent } from './eleve-tile-list.component';

describe('EleveTileListComponent', () => {
  let component: EleveTileListComponent;
  let fixture: ComponentFixture<EleveTileListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EleveTileListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EleveTileListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
