import { animate, animateChild, group, query, style, transition, trigger } from '@angular/animations';

const optional = { optional: true };

export const routeAnimations =
  trigger('routeAnimations', [
    transition('SelectionEleve => SelectionObjectif, SelectionObjectif => ValidationObjectif', slideTo('right')),
    transition('SelectionObjectif => SelectionEleve, ValidationObjectif => SelectionObjectif', slideTo('left')),
    transition('* => SelectionEleve', fadeIn())
  ]);


function fadeIn() {
  return [
    style({ position: 'relative' }),
    query(':enter, :leave', [
      style({
        position: 'absolute',
        top: 0,
        left: 0,
        width: '100%'
      })
    ], optional),
    query(':enter', [
      style({ opacity: 0 })
    ]),
    query(':leave', animateChild(), optional),
    query(':leave', [
      animate('300ms ease-out', style({ opacity: 0 }))
    ], optional),
    query(':enter', [
      animate('300ms ease-out', style({ opacity: 1 }))
    ]),
    query(':enter', animateChild()),
  ];
}

function slideTo(direction: string) {
  return [
    style({ position: 'relative' }),
    query(':enter, :leave', [
      style({
        position: 'absolute',
        top: 0,
        [direction]: 0,
        width: '100%'
      })
    ], optional),
    query(':enter', [
      style({ [direction]: '-100%' })
    ]),
    query(':leave', animateChild(), optional),
    group([
      query(':leave', [
        animate('600ms ease', style({ [direction]: '100%' }))
      ], optional),
      query(':enter', [
        animate('600ms ease', style({ [direction]: '0%' }))
      ])
    ]),
    query(':enter', animateChild()),
  ];
}