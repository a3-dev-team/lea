import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Eleve } from '../models/eleve.model';
import { EleveService } from './eleve.service';


let httpClientSpy: jasmine.SpyObj<HttpClient>;

describe('EleveService', () => {
  let httpTestingController: HttpTestingController;
  let service: EleveService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });

    // Inject the http service and test controller for each test
    TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);
    service = TestBed.inject(EleveService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return expected eleves (HttpClient called once)', () => {
    const testData: Eleve[] =
      [{ id: 1, nom: 'nom1', prenom: 'prenom1' }, { id: 2, nom: 'nom2', prenom: 'prenom2' }];

    service.eleves$.subscribe(data =>
      expect(data).toBe(testData)
    );

    const testRequest = httpTestingController.expectOne('https://localhost:7057/api/lea/cycle1/v1/eleves');
    expect(testRequest.request.method).toEqual('GET');
    testRequest.flush(testData);

    httpTestingController.verify();
  });

});
