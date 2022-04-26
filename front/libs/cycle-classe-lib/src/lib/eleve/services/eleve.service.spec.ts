import { ENVIRONMENT, IEnvironment } from '@a3/shared-lib';
import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Eleve } from '../models/eleve.model';
import { EleveService } from './eleve.service';


let httpClientSpy: jasmine.SpyObj<HttpClient>;

describe('EleveService', () => {
  let environmentStub: Partial<IEnvironment>;
  environmentStub = {
    production: false,
    tokenName: 'tokenName',
    backUrl: 'https://localhost:7057/'
  };

  let httpTestingController: HttpTestingController;
  let service: EleveService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        { provide: ENVIRONMENT, useValue: environmentStub }
      ]
    });

    httpTestingController = TestBed.inject(HttpTestingController);
    service = TestBed.inject(EleveService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return expected eleves (HttpClient called once)', () => {
    const testData: Eleve[] =
      [
        new Eleve({ id: 1, nom: 'nom1', prenom: 'prenom1', emails: ['prenom1.nom1@lea.fr'], dateNaissance: new Date(2022, 1, 3) }),
        new Eleve({ id: 2, nom: 'nom2', prenom: 'prenom2', emails: ['prenom2.nom2@lea.fr'], dateNaissance: new Date(2021, 2, 4) })
      ];

    service.chargerListeEleveClasse(1).subscribe(data =>
      expect(data).toBe(testData)
    );

    const testRequest = httpTestingController.expectOne('https://localhost:7057/api/lea/cycle1/v1/classes/1/eleves');
    expect(testRequest.request.method).toEqual('GET');
    testRequest.flush(testData);

    httpTestingController.verify();
  });

});
