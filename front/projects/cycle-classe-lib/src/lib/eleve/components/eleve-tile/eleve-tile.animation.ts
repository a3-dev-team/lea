import { animate, state, style, transition, trigger } from '@angular/animations';

export const eleveTileAnimation =
    trigger('eleveTileAnimation', [
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
    ]);