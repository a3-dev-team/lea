import { SharedLibModule } from '@a3/shared-lib';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { EleveDetailComponent } from './components/eleve-detail/eleve-detail.component';
import { EleveListComponent } from './components/eleve-list/eleve-list.component';
import { EleveTileListComponent } from './components/eleve-tile-list/eleve-tile-list.component';
import { EleveTileComponent } from './components/eleve-tile/eleve-tile.component';

@NgModule({
  declarations: [
    EleveDetailComponent,
    EleveListComponent,
    EleveTileComponent,
    EleveTileListComponent
  ],
  imports: [
    SharedLibModule,
    CommonModule
  ],
  exports: [
    EleveDetailComponent,
    EleveListComponent,
    EleveTileComponent,
    EleveTileListComponent
  ]
})
export class EleveModule { }
