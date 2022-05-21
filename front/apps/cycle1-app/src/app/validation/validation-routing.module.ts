import { AuthenticationGuard } from '@a3/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ValidationGuard } from './guard/validation.guard';
import { SelectionEleveComponent } from './pages/selection-eleve/selection-eleve.component';
import { SelectionObjectifComponent } from './pages/selection-objectif/selection-objectif.component';
import { ValidationObjectifComponent } from './pages/validation-objectif/validation-objectif.component';
import { ValidationComponent } from './validation.component';

const routes: Routes = [
  {
    path: '',
    component: ValidationComponent,
    canActivateChild: [AuthenticationGuard],
    canDeactivate: [ValidationGuard],
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