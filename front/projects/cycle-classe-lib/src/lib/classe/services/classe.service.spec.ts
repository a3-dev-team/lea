import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Classe } from '../models/classe.model';
import { ClasseService } from './classe.service';


describe('ClasseService', () => {
  let httpTestingController: HttpTestingController;
  let service: ClasseService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    httpTestingController = TestBed.inject(HttpTestingController);
    service = TestBed.inject(ClasseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return expected classe (HttpClient called once)', () => {
    const testData: Classe = new Classe({ id: 1, nom: 'classe1' });

    service.chargerClasse(1).subscribe(data =>
      expect(data).toBe(testData)
    );

    const testRequest = httpTestingController.expectOne('https://localhost:7057/api/lea/cycle1/v1/classes/1');
    expect(testRequest.request.method).toEqual('GET');
    testRequest.flush(testData);

    httpTestingController.verify();
  });

});
