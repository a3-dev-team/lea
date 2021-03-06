import { EleveStore } from '@a3/cycle-classe-lib';
import { ENVIRONMENT, IEnvironment } from '@a3/shared-lib';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { of } from 'rxjs';
import { ApplicationStore } from '../../../core/application-store/application-store';
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

    let environmentStub: Partial<IEnvironment>;
    environmentStub = {
      production: false,
      tokenName: 'tokenName',
      backUrl: 'https://localhost:7057'
    };

    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        RouterTestingModule],
      declarations: [SelectionEleveComponent],
      providers: [
        ApplicationStore,
        { provide: EleveStore, useValue: eleveStoreStub },
        { provide: ENVIRONMENT, useValue: environmentStub }
      ]

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
