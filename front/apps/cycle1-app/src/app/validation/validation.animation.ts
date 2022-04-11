import { fadeIn, slideTo } from '@a3/shared-lib';
import { transition, trigger } from '@angular/animations';

const optional = { optional: true };

export const routeAnimations =
  trigger('routeAnimations', [
    transition('SelectionEleve => SelectionObjectif, SelectionObjectif => ValidationObjectif', slideTo('right')),
    transition('SelectionObjectif => SelectionEleve, ValidationObjectif => SelectionObjectif', slideTo('left')),
    transition('* => SelectionEleve', fadeIn())
  ]);

