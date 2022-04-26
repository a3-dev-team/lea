import { ENVIRONMENT, IEnvironment } from '@a3/shared-lib';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { EleveService } from '../services/eleve.service';
import { EleveStore } from './eleve-store';


describe('EleveStore', () => {
  let environmentStub: Partial<IEnvironment>;
  environmentStub = {
    production: false,
    tokenName: 'tokenName',
    backUrl: 'https://localhost:7057/'
  };

  let service: EleveStore;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        EleveService,
        HttpClient,
        HttpHandler,
        { provide: ENVIRONMENT, useValue: environmentStub }]
    });
    service = TestBed.inject(EleveStore);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
