import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BehaviorSubject, take } from 'rxjs';
import { Eleve } from '../../models/eleve.model';
import { eleveTileAnimation } from './eleve-tile.animation';

@Component({
  selector: 'classe-eleve-tile',
  templateUrl: './eleve-tile.component.html',
  styleUrls: ['./eleve-tile.component.css'],
  animations: [eleveTileAnimation],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EleveTileComponent implements OnInit {


  private selectedSubject = new BehaviorSubject<boolean>(false);
  public selectedState$ = this.selectedSubject.asObservable();

  @Input() public eleve!: Eleve | null;
  @Output() public selected: EventEmitter<Eleve | null> = new EventEmitter<Eleve | null>();


  constructor() { }

  ngOnInit(): void {
    console.log(this.eleve);
  }

  public onTileClick(): void {
    this.selectEleve();
  }
  public onCloseButtonClick(e: Event): void {
    e.stopPropagation();
    this.unSelectEleve();
  }

  private selectEleve() {
    this.selectedState$
      .pipe(take(1))
      .subscribe((selected: boolean) => {
        if (!selected) {
          this.selected.emit(this.eleve);
          this.selectedSubject.next(true)
        }
      });
  }

  private unSelectEleve() {
    this.selectedState$
      .pipe(take(1))
      .subscribe((selected: boolean) => {
        if (selected) {
          this.selectedSubject.next(false)
        }
      });
  }
}
