import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AuthenticationManager } from './authentication-manager.service';


describe('AuthenticationManager', () => {
  let service: AuthenticationManager;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule
      ]
    });
    service = TestBed.inject(AuthenticationManager);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
