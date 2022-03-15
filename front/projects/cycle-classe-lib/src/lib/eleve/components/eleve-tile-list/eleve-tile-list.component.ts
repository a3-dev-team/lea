import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Eleve } from '../../models/eleve.model';

@Component({
  selector: 'classe-eleve-tile-list',
  templateUrl: './eleve-tile-list.component.html',
  styleUrls: ['./eleve-tile-list.component.css']
})
export class EleveTileListComponent implements OnInit {


  @Input() public eleves$!: Observable<Eleve[]>
  @Output() public selection: EventEmitter<Eleve> = new EventEmitter<Eleve>();

  constructor() { }

  ngOnInit(): void {
  }

  onEleveSelected(eleve: Eleve) {
    this.selection.emit(eleve);
  }

}
