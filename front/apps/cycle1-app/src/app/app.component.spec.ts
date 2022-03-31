import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ENVIRONMENT, IEnvironment } from '@shared-lib';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let environmentStub: Partial<IEnvironment>;
  environmentStub = {
    production: false,
    tokenName: 'tokenName',
    backUrl: 'https://localhost:7057'
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        RouterTestingModule
      ],
      providers: [
        { provide: ENVIRONMENT, useValue: environmentStub }
      ],
      declarations: [
        AppComponent
      ],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

});
