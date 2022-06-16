import { animate, state, style, transition, trigger } from '@angular/animations';

export const modalAnimations =
    trigger('modalAnimations', [
        state('visible',
            style({})
        ),
        state('notVisible',
            style({
                left: '100%',
                right: '-100%'
            })
        ),
        transition('visible => notVisible', [
            animate('300ms')
        ]),
        transition('notVisible => visible', [
            animate('200ms')
        ]),
    ]);