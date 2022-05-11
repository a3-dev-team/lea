import { TestBed } from '@angular/core/testing';
import { ObjectifEleveService } from '../services/objectif-eleve.service';
import { ObjectifEleveCache } from './objectif-eleve.cache';


describe('ObjectifEleveCache', () => {
  let service: ObjectifEleveCache;
  let objectifEleveServiceStub: Partial<ObjectifEleveService>;
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        { provide: ObjectifEleveService, useValue: objectifEleveServiceStub }
      ]
    });
    service = TestBed.inject(ObjectifEleveCache);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
