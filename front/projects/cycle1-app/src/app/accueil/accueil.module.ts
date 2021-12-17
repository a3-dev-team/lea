import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedLibModule } from '@shared-lib';
import { AccueilRoutingModule } from './accueil-routing.module';
import { AccueilComponent } from './accueil.component';




@NgModule({
  declarations: [
    AccueilComponent
  ],
  imports: [
    SharedLibModule,
    CommonModule,
    AccueilRoutingModule
  ]
})
export class AccueilModule { }
