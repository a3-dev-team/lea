import { TestBed } from '@angular/core/testing';
import { LoaderManager } from './loader-manager.service';


describe('LoaderManager', () => {
  let service: LoaderManager;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoaderManager);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
