import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Eleve } from '../../models/eleve.model';

@Component({
  selector: 'classe-eleve-list',
  templateUrl: './eleve-list.component.html',
  styleUrls: ['./eleve-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EleveListComponent implements OnInit {

  @Input() public eleves$!: Observable<Eleve[]>

  constructor() { }

  ngOnInit(): void { }

}
