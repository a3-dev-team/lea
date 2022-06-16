import { fadeIn, slideTo } from '@a3/shared-lib';
import { animate, state, style, transition, trigger } from '@angular/animations';

const optional = { optional: true };

export const routeAnimations =
  trigger('routeAnimations', [
    transition('SelectionEleve => SelectionObjectif, SelectionObjectif => ValidationObjectif', slideTo('left')),
    transition('SelectionObjectif => SelectionEleve, ValidationObjectif => SelectionObjectif', slideTo('right')),
    transition('* => SelectionEleve', fadeIn())
  ]);

export const validationAnimations =
  trigger('validationAnimations', [
    state('visible',
      style({
        opacity: 1
      })
    ),
    state('notVisible',
      style({
        opacity: 0
      })
    ),
    transition('visible => notVisible', [
      animate('600ms')
    ]),
    transition('notVisible => visible', [
      animate('600ms')
    ]),
    transition(':enter', [
      style({ opacity: 0 }),
      animate('900ms ease-out', style({ opacity: 1 }))
    ]),
    transition(':leave', [
      style({ opacity: 1 }),
      animate('600ms ease-out', style({ opacity: 0 }))
    ])
  ]);

