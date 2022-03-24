import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatCardModule } from '@angular/material/card';
import { RouterTestingModule } from '@angular/router/testing';
import { EleveStore } from 'projects/cycle-classe-lib/src/lib/eleve/store/eleve-store';
import { of } from 'rxjs';
import { CycleClasseLibModule } from './../../../../../cycle-classe-lib/src/lib/cycle-classe-lib.module';
import { ApplicationStore } from './../../core/application-store/application-store';
import { SelectionEleveComponent } from './selection-eleve.component';


describe('SelectionEleveComponent', () => {
  let component: SelectionEleveComponent;
  let fixture: ComponentFixture<SelectionEleveComponent>;
  let eleveStore: EleveStore;

  beforeEach(async () => {
    let eleveStoreStub: Partial<EleveStore>;
    eleveStoreStub = {
      eleves$: of()
    };

    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        RouterTestingModule,
        MatCardModule,
        CycleClasseLibModule],
      declarations: [SelectionEleveComponent],
      providers: [ApplicationStore, { provide: EleveStore, useValue: eleveStoreStub }]

    })
      .compileComponents();
    eleveStore = TestBed.inject(EleveStore);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectionEleveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    eleveStore.eleves$ = of();
    expect(component).toBeTruthy();
  });
});
