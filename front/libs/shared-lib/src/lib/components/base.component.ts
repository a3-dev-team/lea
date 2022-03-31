import { Directive, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';

@Directive({})
export class BaseComponent implements OnInit, OnDestroy {

  private destroySubject = new Subject<void>();
  protected destroyAction$ = this.destroySubject.asObservable();

  constructor() { }

  ngOnDestroy(): void {
    this.destroySubject.next();
  }

  ngOnInit(): void {
  }

}
