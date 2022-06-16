import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { ObjectifEleve } from '../../models/objectif-eleve.model';
import { objectifEleveTileAnimations } from './objectif-eleve-tile.animation';

@Component({
  selector: 'objectif-objectif-eleve-tile',
  templateUrl: './objectif-eleve-tile.component.html',
  animations: [objectifEleveTileAnimations],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ObjectifEleveTileComponent implements OnInit {

  @Input() public objectifEleve!: ObjectifEleve | null;
  @Input() public class!: string | null;

  constructor() { }

  ngOnInit(): void {
  }

}
