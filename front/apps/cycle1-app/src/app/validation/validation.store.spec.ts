import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ValidationStore } from './validation.store';


describe('ValidationStore', () => {
  let service: ValidationStore;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(ValidationStore);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
