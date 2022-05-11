import { TestBed } from '@angular/core/testing';
import { EleveService } from '../services/eleve.service';
import { EleveCache } from './eleve.cache';


describe('EleveCache', () => {
  let service: EleveCache;
  let eleveServiceStub: Partial<EleveService>;
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        { provide: EleveService, useValue: eleveServiceStub }
      ]
    });
    service = TestBed.inject(EleveCache);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
