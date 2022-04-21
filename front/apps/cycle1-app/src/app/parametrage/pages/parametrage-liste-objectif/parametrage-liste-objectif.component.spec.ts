import { ObjectifStore } from '@a3/cycle1-objectif-lib';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { ParametrageListeObjectifComponent } from './parametrage-liste-objectif.component';


describe('ParametrageListeObjectifComponent', () => {
  let component: ParametrageListeObjectifComponent;
  let fixture: ComponentFixture<ParametrageListeObjectifComponent>;
  let objectifStore: ObjectifStore;

  beforeEach(async () => {
    let objectifStoreStub: Partial<ObjectifStore>;
    objectifStoreStub = {
      objectifs$: of()
    };


    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      declarations: [ParametrageListeObjectifComponent],
      providers: [
        { provide: ObjectifStore, useValue: objectifStoreStub },
      ]
    })
      .compileComponents();
    objectifStore = TestBed.inject(ObjectifStore);
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
