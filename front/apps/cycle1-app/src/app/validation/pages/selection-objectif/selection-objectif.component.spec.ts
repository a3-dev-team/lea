import { QrcodeReaderModule } from '@a3/camera';
import { ENVIRONMENT, IEnvironment } from '@a3/shared-lib';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { SelectionObjectifComponent } from './selection-objectif.component';


describe('SelectionObjectifComponent', () => {
  let component: SelectionObjectifComponent;
  let fixture: ComponentFixture<SelectionObjectifComponent>;

  beforeEach(async () => {
    // class validationStoreMock extends ValidationStore {
    //   override mettreAJourEleveParId(eleveId: number | null) { };
    //   override mettreAJourObjectifEleve(objectifEleve: ObjectifEleve | null) { };
    // };
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
        QrcodeReaderModule
      ],
      declarations: [SelectionObjectifComponent],
      providers: [
        // { provide: ValidationStore, useValue: validationStoreMock },
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
