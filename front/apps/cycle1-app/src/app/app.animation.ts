import { transition, trigger } from '@angular/animations';
import { fadeIn, slideTo } from '@shared-lib';



export const routeAnimations =
  trigger('routeAnimations', [
    transition('* => SignIn, SignIn => *', fadeIn()),
    transition('Accueil => *', slideTo('right')),
    transition('* => Accueil', slideTo('left'))
  ]);