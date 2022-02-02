import { TestBed } from '@angular/core/testing';
import { ErrorManager } from './error-manager.service';


describe('ErrorManagerService', () => {
  let service: ErrorManager;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ErrorManager);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
