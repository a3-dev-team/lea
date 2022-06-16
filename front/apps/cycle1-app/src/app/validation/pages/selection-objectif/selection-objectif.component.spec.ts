import { QrcodeReaderModule } from '@a3/camera';
import { ObjectifEleve, ObjectifEleveCache } from '@a3/cycle1-objectif-lib';
import { ENVIRONMENT, IEnvironment } from '@a3/shared-lib';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { Observable, of } from 'rxjs';
import { ApplicationStore } from '../../../core/application-store/application-store';
import { ValidationStore } from '../../store/validation.store';
import { SelectionObjectifComponent } from './selection-objectif.component';


describe('SelectionObjectifComponent', () => {
  let component: SelectionObjectifComponent;
  let fixture: ComponentFixture<SelectionObjectifComponent>;

  beforeEach(async () => {
    class ObjectifEleveCacheMock extends ObjectifEleveCache {
      public override chargerObjectifEleve(eleveId: number, objectifId: number): Observable<ObjectifEleve | null> {
        return of(new ObjectifEleve({ eleveId: 1, objectifId: 1 }));
      }
    }

    let environmentStub: Partial<IEnvironment>;
    environmentStub = {
      production: false,
      tokenName: 'tokenName',
      backUrl: 'https://localhost:7057'
    };

    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule,
        BrowserAnimationsModule,
        QrcodeReaderModule
      ],
      declarations: [SelectionObjectifComponent],
      providers: [
        ApplicationStore,
        ValidationStore,
        { provide: ObjectifEleveCache, useValue: ObjectifEleveCacheMock },
        { provide: ENVIRONMENT, useValue: environmentStub }
      ]
    })
      .compileComponents();
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
