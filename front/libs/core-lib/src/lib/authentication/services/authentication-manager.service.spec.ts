import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ENVIRONMENT, IEnvironment } from '@shared-lib';
import { AuthenticationManager } from './authentication-manager.service';


describe('AuthenticationManager', () => {
  let environmentStub: Partial<IEnvironment>;
  environmentStub = {
    production: false,
    tokenName: 'tokenName',
    backUrl: 'https://localhost:7057/'
  };

  let service: AuthenticationManager;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule
      ],
      providers: [
        { provide: ENVIRONMENT, useValue: environmentStub }
      ]
    });
    service = TestBed.inject(AuthenticationManager);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
