import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedLibModule } from '@shared-lib';
import { EleveDetailComponent } from './components/eleve-detail/eleve-detail.component';
import { EleveListComponent } from './components/eleve-list/eleve-list.component';

@NgModule({
  declarations: [
    EleveDetailComponent,
    EleveListComponent
  ],
  imports: [
    SharedLibModule,
    CommonModule
  ],
  exports: [
    EleveDetailComponent,
    EleveListComponent
  ]
})
export class EleveModule {}
