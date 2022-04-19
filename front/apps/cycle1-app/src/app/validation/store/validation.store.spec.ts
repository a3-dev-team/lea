import { EleveService } from '@a3/cycle-classe-lib';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ValidationStore } from './validation.store';


describe('ValidationStore', () => {
  let service: ValidationStore;

  beforeEach(() => {
    let eleveServiceStub: Partial<EleveService>;
    eleveServiceStub = {
    };

    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [
        { provide: EleveService, useValue: eleveServiceStub },
      ]
    });
    service = TestBed.inject(ValidationStore);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
