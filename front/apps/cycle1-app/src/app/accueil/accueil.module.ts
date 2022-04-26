import { SharedLibModule } from '@a3/shared-lib';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AccueilRoutingModule } from './accueil-routing.module';
import { AccueilComponent } from './pages/accueil/accueil.component';




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
