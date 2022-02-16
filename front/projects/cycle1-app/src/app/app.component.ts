import { Component } from '@angular/core';
import { AuthenticationManager } from '@core-lib';
import { slideInAnimation } from './app.animation';
import { ApplicationStore } from './core/application-store/application-store';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [
    slideInAnimation
  ]
})
export class AppComponent {

  constructor(
    public readonly authenticationManager: AuthenticationManager,
    public readonly applicationStore: ApplicationStore) { }

}
