import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ObjectifEleveTileListComponent } from './components/objectif-eleve-tile-list/objectif-eleve-tile-list.component';
import { ObjectifEleveTileComponent } from './components/objectif-eleve-tile/objectif-eleve-tile.component';



@NgModule({
  declarations: [
    ObjectifEleveTileComponent,
    ObjectifEleveTileListComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ObjectifEleveTileComponent,
    ObjectifEleveTileListComponent
  ]
})
export class ObjectifEleveModule { }
