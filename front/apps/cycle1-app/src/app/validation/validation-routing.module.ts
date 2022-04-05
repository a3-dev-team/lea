import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationGuard } from '@core-lib';
import { SelectionEleveComponent } from './selection-eleve/selection-eleve.component';
import { SelectionObjectifComponent } from './selection-objectif/selection-objectif.component';
import { ValidationObjectifComponent } from './validation-objectif/validation-objectif.component';
import { ValidationComponent } from './validation.component';

const routes: Routes = [
  {
    path: '',
    component: ValidationComponent,
    canActivateChild: [AuthenticationGuard],
    children: [

      { path: '', redirectTo: 'eleves', pathMatch: 'full' },
      {
        path: 'eleves', component: SelectionEleveComponent,
        data: { animationState: 'SelectionEleve' }
      },
      {
        path: 'eleves/:eleveId/objectifs',
        component: SelectionObjectifComponent,
        data: { animationState: 'SelectionObjectif' },
      },
      {
        path: 'eleves/:eleveId/objectifs/:objectifId',
        component: ValidationObjectifComponent,
        data: { animationState: 'ValidationObjectif' },
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ValidationRoutingModule { }