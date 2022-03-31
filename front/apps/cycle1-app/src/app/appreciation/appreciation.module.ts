import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppreciationRoutingModule } from './appreciation-routing.module';
import { SelectionEleveComponent } from './selection-eleve/selection-eleve.component';
import { AppreciationComponent } from './appreciation.component';
import { DetailEleveComponent } from './detail-eleve/detail-eleve.component';


@NgModule({
  declarations: [
    SelectionEleveComponent,
    AppreciationComponent,
    DetailEleveComponent
  ],
  imports: [
    CommonModule,
    AppreciationRoutingModule
  ]
})
export class AppreciationModule { }
