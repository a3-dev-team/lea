
import { Component, OnDestroy, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ValidationStore } from './store/validation.store';
import { routeAnimations } from './validation.animation';

@Component({
  selector: 'app-validation',
  templateUrl: './validation.component.html',
  styleUrls: ['./validation.component.scss'],
  animations: [
    routeAnimations
  ]
})
export class ValidationComponent implements OnInit, OnDestroy {

  constructor(public readonly validationStore: ValidationStore) {
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

  public prepareRoute(routerOutlet: RouterOutlet) {
    return routerOutlet &&
      routerOutlet.activatedRouteData &&
      routerOutlet.activatedRouteData['animationState'];
  }

}
