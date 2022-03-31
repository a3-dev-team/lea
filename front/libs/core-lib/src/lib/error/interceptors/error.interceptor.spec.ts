import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ENVIRONMENT, IEnvironment } from '@shared-lib';
import { AuthenticationManager } from '../../authentication/services/authentication-manager.service';
import { ErrorInterceptor } from './error.interceptor';


describe('ErrorInterceptor', () => {
  let environmentStub: Partial<IEnvironment>;
  environmentStub = {
    production: false,
    tokenName: 'tokenName',
    backUrl: 'https://localhost:7057/'
  };

  beforeEach(() => TestBed.configureTestingModule({
    imports: [
      RouterTestingModule,
      HttpClientTestingModule
    ],
    providers: [
      AuthenticationManager,
      ErrorInterceptor,
      { provide: ENVIRONMENT, useValue: environmentStub }
    ]
  }));

  it('should be created', () => {
    const interceptor: ErrorInterceptor = TestBed.inject(ErrorInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
