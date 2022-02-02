import { Component } from '@angular/core';
import { AuthenticationManager } from 'projects/core-lib/src/lib/authentication/services/authentication-manager.service';
import { ApplicationStore } from './core/application-store/application-store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(
    public readonly authenticationManager: AuthenticationManager,
    public readonly applicationStore: ApplicationStore) { }

}
