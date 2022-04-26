import { ENVIRONMENT, IEnvironment } from '@a3/shared-lib';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ObjectifService } from './objectif.service';


describe('ObjectifService', () => {
  let environmentStub: Partial<IEnvironment>;
  environmentStub = {
    production: false,
    tokenName: 'tokenName',
    backUrl: 'https://localhost:7057/'
  };

  let service: ObjectifService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        { provide: ENVIRONMENT, useValue: environmentStub }
      ]
    });
    service = TestBed.inject(ObjectifService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
