import { ObjectifModule } from '@a3/cycle1-objectif-lib';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../../shared/shared.module';
import { ParametrageListeObjectifComponent } from './parametrage-liste-objectif.component';



@NgModule({
  declarations: [
    ParametrageListeObjectifComponent
  ],
  imports: [
    RouterModule,
    SharedModule,
    ObjectifModule
  ]
})
export class ParametrageListeObjectifModule { }
