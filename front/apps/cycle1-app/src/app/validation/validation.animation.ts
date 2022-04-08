import { transition, trigger } from '@angular/animations';
import { fadeIn, slideTo } from '@shared-lib';

const optional = { optional: true };

export const routeAnimations =
  trigger('routeAnimations', [
    transition('SelectionEleve => SelectionObjectif, SelectionObjectif => ValidationObjectif', slideTo('right')),
    transition('SelectionObjectif => SelectionEleve, ValidationObjectif => SelectionObjectif', slideTo('left')),
    transition('* => SelectionEleve', fadeIn())
  ]);

