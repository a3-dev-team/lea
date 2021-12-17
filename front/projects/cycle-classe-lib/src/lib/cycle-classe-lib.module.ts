import { NgModule } from '@angular/core';
import { EleveModule } from './eleve/eleve.module';

@NgModule({
  declarations: [
  ],
  imports: [
    EleveModule
  ],
  exports: [
    EleveModule
  ]
})
export class CycleClasseLibModule { }

