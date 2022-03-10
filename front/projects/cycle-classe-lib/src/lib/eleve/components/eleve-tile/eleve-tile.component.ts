import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Eleve } from '../../models/eleve.model';

@Component({
  selector: 'classe-eleve-tile',
  templateUrl: './eleve-tile.component.html',
  styleUrls: ['./eleve-tile.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EleveTileComponent implements OnInit {


  @Input() public eleve!: Eleve;
  @Output() public selection: EventEmitter<Eleve> = new EventEmitter<Eleve>();


  constructor() { }

  ngOnInit(): void {
    console.log(this.eleve);
  }

  onClick() {
    this.selection.emit(this.eleve);
  }

}
