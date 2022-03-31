import { TestBed } from '@angular/core/testing';
import { ApplicationStore } from './application-store';


describe('ApplicationStore', () => {
  let service: ApplicationStore;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApplicationStore);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
