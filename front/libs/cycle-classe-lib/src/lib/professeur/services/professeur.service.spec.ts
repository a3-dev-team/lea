import { ENVIRONMENT, IEnvironment } from '@a3/shared-lib';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Professeur } from '../models/professeur.model';
import { ProfesseurService } from './professeur.service';


describe('ProfesseurService', () => {
  let environmentStub: Partial<IEnvironment>;
  environmentStub = {
    production: false,
    tokenName: 'tokenName',
    backUrl: 'https://localhost:7057/'
  };

  let httpTestingController: HttpTestingController;
  let service: ProfesseurService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        { provide: ENVIRONMENT, useValue: environmentStub }
      ]
    });
    httpTestingController = TestBed.inject(HttpTestingController)
    service = TestBed.inject(ProfesseurService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return expected professeur (HttpClient called once)', () => {
    const testData: Professeur = new Professeur({ id: 1, prenom: 'Professeur', nom: 'TOURNESOL', email: 'professeur.tournesol@a3.fr' });

    service.chargerProfesseurParEmail('professeur.tournesol@a3.fr').subscribe(data =>
      expect(data).toBe(testData)
    );

    const testRequest = httpTestingController.expectOne('https://localhost:7057/api/lea/cycle1/v1/professeurs/professeur.tournesol@a3.fr');
    expect(testRequest.request.method).toEqual('GET');
    testRequest.flush(testData);

    httpTestingController.verify();
  });
});
