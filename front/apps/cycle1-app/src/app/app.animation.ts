import { fadeIn, slideTo } from '@a3/shared-lib';
import { transition, trigger } from '@angular/animations';



export const routeAnimations =
  trigger('routeAnimations', [
    transition('* => SignIn, SignIn => *', fadeIn()),
    transition('Accueil => *', slideTo('right')),
    transition('* => Accueil', slideTo('left'))
  ]);