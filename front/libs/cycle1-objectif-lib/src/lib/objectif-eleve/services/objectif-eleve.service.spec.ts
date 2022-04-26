import { ENVIRONMENT, IEnvironment } from '@a3/shared-lib';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ObjectifEleveService } from './objectif-eleve.service';


describe('ObjectifEleveService', () => {
  let environmentStub: Partial<IEnvironment>;
  environmentStub = {
    production: false,
    tokenName: 'tokenName',
    backUrl: 'https://localhost:7057/'
  };

  let service: ObjectifEleveService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        { provide: ENVIRONMENT, useValue: environmentStub }
      ]
    });
    service = TestBed.inject(ObjectifEleveService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
