import { AuthenticationGuard } from '@a3/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccueilModule } from './accueil/accueil.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'accueil'
  },
  {
    path: 'accueil', loadChildren: () => AccueilModule,
    data: { animationState: 'Accueil' },
    canActivate: [AuthenticationGuard],
  },
  {
    path: 'validation', loadChildren: () => import('./validation/validation.module').then((module) => module.ValidationModule),
    data: { animationState: 'Validation' },
    canActivate: [AuthenticationGuard],
  },
  {
    path: 'appreciation', loadChildren: () => import('./appreciation/appreciation.module').then((module) => module.AppreciationModule),
    data: { animationState: 'Appreciation' },
    canActivate: [AuthenticationGuard]
  },
  {
    path: 'parametrage', loadChildren: () => import('./parametrage/parametrage.module').then((module) => module.ParametrageModule),
    data: { animationState: 'Parametrage' },
    canActivate: [AuthenticationGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
