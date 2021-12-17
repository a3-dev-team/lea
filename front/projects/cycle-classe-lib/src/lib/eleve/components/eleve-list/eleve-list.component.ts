import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Eleve } from '../../entities/eleve';

@Component({
  selector: 'cycle-eleve-list',
  templateUrl: './eleve-list.component.html',
  styleUrls: ['./eleve-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EleveListComponent implements OnInit {

  @Input() public eleves$!: Observable<Eleve[]>

  constructor() { }

  ngOnInit(): void { }

}
