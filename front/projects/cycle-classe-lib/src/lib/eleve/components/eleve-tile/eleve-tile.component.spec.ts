import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EleveTileComponent } from './eleve-tile.component';

describe('EleveTileComponent', () => {
  let component: EleveTileComponent;
  let fixture: ComponentFixture<EleveTileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EleveTileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EleveTileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
