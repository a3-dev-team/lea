import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SelectionEleveComponent } from './selection-eleve/selection-eleve.component';
import { SelectionObjectifComponent } from './selection-objectif/selection-objectif.component';
import { ValidationObjectifComponent } from './validation-objectif/validation-objectif.component';
import { ValidationComponent } from './validation.component';

const routes: Routes = [
  {
    path: '', component: ValidationComponent,
    children: [

      { path: '', redirectTo: 'eleves', pathMatch: 'full' },
      { path: 'eleves', component: SelectionEleveComponent },
      { path: 'eleves/:ideleve/objectifs', component: SelectionObjectifComponent },
      { path: 'eleves/:ideleve/objectifs/:idobjectif', component: ValidationObjectifComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ValidationRoutingModule { }