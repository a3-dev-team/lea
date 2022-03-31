// Angular
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInComponent } from './pages/sign-in/sign-in.component';

// Routes vers la page de sélection du dossier courant
const routes: Routes = [
    {
        path: 'signIn',
        component: SignInComponent
    },
];

/**
 * Module de routage du module core (A l'ouverture de l'application)
 *
 * @export
 * @class SaisieCaisseRoutingModule
 */
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class AuthenticationRoutingModule { }
