import { TestBed } from '@angular/core/testing';

import { ObjectifEleveService } from './objectif-eleve.service';

describe('ObjectifEleveService', () => {
  let service: ObjectifEleveService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ObjectifEleveService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
