import { AuthenticationGuard } from '@a3/core-lib';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ParametrageListeObjectifComponent } from './pages/parametrage-liste-objectif/parametrage-liste-objectif.component';

const routes: Routes = [
  { path: '', redirectTo: 'liste-objectif', pathMatch: 'full' },
  {
    path: 'liste-objectif',
    component: ParametrageListeObjectifComponent,
    canActivateChild: [AuthenticationGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ParametrageRoutingModule { }