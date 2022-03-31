import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationGuard } from '@core-lib';
import { AccueilModule } from './accueil/accueil.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'accueil'
  },
  {
    path: 'accueil', loadChildren: () => AccueilModule, canActivate: [AuthenticationGuard],
  },
  {
    path: 'validation', loadChildren: () => import('./validation/validation.module').then((module) => module.ValidationModule), canActivate: [AuthenticationGuard],
  },
  {
    path: 'appreciation', loadChildren: () => import('./appreciation/appreciation.module').then((module) => module.AppreciationModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
