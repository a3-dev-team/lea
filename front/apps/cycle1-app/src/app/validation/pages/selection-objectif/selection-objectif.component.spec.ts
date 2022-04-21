import { ObjectifStore } from '@a3/cycle1-objectif-lib';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { of } from 'rxjs';
import { ValidationStore } from '../../store/validation.store';
import { SelectionObjectifComponent } from './selection-objectif.component';


describe('SelectionObjectifComponent', () => {
  let component: SelectionObjectifComponent;
  let fixture: ComponentFixture<SelectionObjectifComponent>;
  let objectifStore: ObjectifStore;

  beforeEach(async () => {
    let validationStoreStub: Partial<ValidationStore>;
    validationStoreStub = {
      eleveState$: of(),
      objectifState$: of()
    };
    let objectifStoreStub: Partial<ObjectifStore>;
    objectifStoreStub = {
      objectifs$: of()
    };

    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule
      ],
      declarations: [SelectionObjectifComponent],
      providers: [
        { provide: ObjectifStore, useValue: objectifStoreStub },
        { provide: ValidationStore, useValue: validationStoreStub }
      ]
    })
      .compileComponents();
    objectifStore = TestBed.inject(ObjectifStore);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectionObjectifComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});