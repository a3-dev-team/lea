import { Component, EventEmitter, HostBinding, Input, Output } from '@angular/core';
import { FullSizeBaseComponent } from '@shared-lib';
import { Observable } from 'rxjs';
import { Eleve } from '../../models/eleve.model';

@Component({
  selector: 'classe-eleve-tile-list',
  templateUrl: './eleve-tile-list.component.html',
  styleUrls: ['./eleve-tile-list.component.scss']
})
export class EleveTileListComponent extends FullSizeBaseComponent {

  @HostBinding('class') class = "core-position-relative"

  @Input() public eleves$!: Observable<Eleve[]>
  @Output() public selection: EventEmitter<Eleve> = new EventEmitter<Eleve>();

  constructor() {
    super();
  }

  onEleveSelected(eleve: Eleve) {
    this.selection.emit(eleve);
  }

}
