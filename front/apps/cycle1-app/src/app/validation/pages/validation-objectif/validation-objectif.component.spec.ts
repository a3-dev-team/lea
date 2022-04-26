import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { WebcamModule } from 'ngx-webcam';
import { ValidationStore } from '../../store/validation.store';
import { ValidationObjectifComponent } from './validation-objectif.component';


describe('ValidationObjectifComponent', () => {
  let component: ValidationObjectifComponent;
  let fixture: ComponentFixture<ValidationObjectifComponent>;

  beforeEach(async () => {
    class validationStoreMock extends ValidationStore {
      override mettreAJourObjectifEleveParId(eleveId: number | null, objectifId: number | null) { }
    };

    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        WebcamModule
      ],
      declarations: [ValidationObjectifComponent],
      providers: [
        { provide: ValidationStore, useValue: validationStoreMock }
      ]

    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidationObjectifComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
