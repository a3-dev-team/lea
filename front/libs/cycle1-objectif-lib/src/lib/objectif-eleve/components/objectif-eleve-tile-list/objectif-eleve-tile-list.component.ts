import { FullSizeBaseComponent } from '@a3/shared-lib';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ObjectifEleve } from '../../models/objectif-eleve.model';

@Component({
  selector: 'objectif-objectif-eleve-tile-list',
  templateUrl: './objectif-eleve-tile-list.component.html'
})
export class ObjectifEleveTileListComponent extends FullSizeBaseComponent {

  @Input() public objectifEleveList!: ObjectifEleve[] | null
  @Output() public selected: EventEmitter<ObjectifEleve> = new EventEmitter<ObjectifEleve>();

  constructor() {
    super();
  }

  onClickObjectifEleveTile(objectifEleve: ObjectifEleve) {
    this.selected.emit(objectifEleve);
  }


}
