import { HttpClient, HttpHandler } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { EleveService } from './../services/eleve.service';
import { EleveStore } from './eleve-store';


describe('EleveStore', () => {
  let service: EleveStore;

  beforeEach(() => {
    TestBed.configureTestingModule({ providers: [EleveService, HttpClient, HttpHandler] });
    service = TestBed.inject(EleveStore);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
