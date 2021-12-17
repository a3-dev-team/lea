import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppreciationComponent } from './appreciation.component';
import { DetailEleveComponent } from './detail-eleve/detail-eleve.component';
import { SelectionEleveComponent } from './selection-eleve/selection-eleve.component';

const routes: Routes = [
  {
    path:'', component:AppreciationComponent
  },
  {
    path:'eleves', component:SelectionEleveComponent
  },
  {
    path:'eleves/:ideleve', component:DetailEleveComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppreciationRoutingModule { }
