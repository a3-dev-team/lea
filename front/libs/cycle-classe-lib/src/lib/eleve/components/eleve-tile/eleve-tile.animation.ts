import { animate, state, style, transition, trigger } from '@angular/animations';

export const eleveTileAnimations =
    trigger('eleveTileAnimations', [
        state('selected', style({
            position: 'absolute'

        })),
        state('notSelected', style({
            position: 'initial'
        })),
        transition('selected => notSelected', [
            animate('300ms ease-out')
        ]),
        transition('notSelected => selected', [
            animate('300ms ease-out')
        ]),
        transition(':enter', [
            style({ opacity: 0 }),
            animate('600ms ease-out', style({ opacity: 1 }))
        ]),
        transition(':leave', [
            animate('600ms ease-out', style({ opacity: 0 }))
        ])
    ]);