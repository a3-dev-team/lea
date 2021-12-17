import { Component } from '@angular/core';
import { ApplicationStore } from './core/application-store/application-store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(public readonly applicationStore: ApplicationStore) { }
}
