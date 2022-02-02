import { TestBed } from '@angular/core/testing';

import { LoaderManagerService } from './loader-manager.service';

describe('LoaderManagerService', () => {
  let service: LoaderManagerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoaderManagerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
