import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Eleve } from '../../entities/eleve';


@Component({
  selector: 'cycle-eleve-detail',
  templateUrl: './eleve-detail.component.html',
  styleUrls: ['./eleve-detail.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EleveDetailComponent implements OnInit {

  @Input() public eleve!: Eleve;
  @Output() public selection: EventEmitter<Eleve> = new EventEmitter<Eleve>()

  constructor() { }

  ngOnInit(): void {
  }

  onSelectionnerClick() {
    this.selection.emit(this.eleve);
  }

}
