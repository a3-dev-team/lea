import { FullSizeBaseComponent } from '@a3/shared-lib';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Eleve } from '../../models/eleve.model';

@Component({
  selector: 'classe-eleve-tile-list',
  templateUrl: './eleve-tile-list.component.html'
})
export class EleveTileListComponent extends FullSizeBaseComponent {

  @Input() public eleves$!: Observable<Eleve[]>
  @Output() public selected: EventEmitter<Eleve> = new EventEmitter<Eleve>();

  constructor() {
    super();
  }

  onEleveSelected(eleve: Eleve) {
    this.selected.emit(eleve);
  }

}
