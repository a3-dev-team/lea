import { Directive, HostBinding } from '@angular/core';
import { BaseComponent } from './base.component';

@Directive({})
export class FullSizeBaseComponent extends BaseComponent {

  constructor() {
    super();
  }
  @HostBinding('class') fullSizeClass = 'core-width-100 core-height-100';

}
