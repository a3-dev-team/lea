import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { Cycle1ObjectifLibModule, ObjectifStore } from '@cycle1-objectif-lib';
import { of } from 'rxjs';
import { SelectionObjectifComponent } from './selection-objectif.component';


describe('SelectionObjectifComponent', () => {
  let component: SelectionObjectifComponent;
  let fixture: ComponentFixture<SelectionObjectifComponent>;
  let objectifStore: ObjectifStore;

  beforeEach(async () => {
    let objectifStoreStub: Partial<ObjectifStore>;
    objectifStoreStub = {
      objectifs$: of()
    };

    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        Cycle1ObjectifLibModule
      ],
      declarations: [SelectionObjectifComponent],
      providers: [{ provide: ObjectifStore, useValue: objectifStoreStub }]
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
    objectifStore.objectifs$ = of();
    expect(component).toBeTruthy();
  });
});
