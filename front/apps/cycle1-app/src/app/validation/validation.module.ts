import { CameraModule } from '@a3/camera';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CycleClasseLibModule } from '@cycle-classe-lib';
import { Cycle1ObjectifLibModule } from '@cycle1-objectif-lib';
import { WebcamModule } from 'ngx-webcam';
import { SharedModule } from '../shared/shared.module';
import { SelectionEleveComponent } from './selection-eleve/selection-eleve.component';
import { SelectionObjectifComponent } from './selection-objectif/selection-objectif.component';
import { ValidationObjectifComponent } from './validation-objectif/validation-objectif.component';
import { ValidationRoutingModule } from './validation-routing.module';
import { ValidationComponent } from './validation.component';

@NgModule({
  declarations: [
    ValidationComponent,
    ValidationObjectifComponent,
    SelectionEleveComponent,
    SelectionObjectifComponent,
    SelectionObjectifComponent,
    ValidationObjectifComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    ValidationRoutingModule,
    CycleClasseLibModule,
    Cycle1ObjectifLibModule,
    CameraModule,
    WebcamModule,
  ]
})
export class ValidationModule { }
