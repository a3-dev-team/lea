import { TestBed } from '@angular/core/testing';

import { ErreurInterceptor } from './erreur.interceptor';

describe('ErreurInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      ErreurInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: ErreurInterceptor = TestBed.inject(ErreurInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
