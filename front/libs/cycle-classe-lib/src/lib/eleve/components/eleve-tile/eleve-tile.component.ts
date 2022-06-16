import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BehaviorSubject, take } from 'rxjs';
import { Eleve } from '../../models/eleve.model';
import { eleveTileAnimations } from './eleve-tile.animation';

@Component({
  selector: 'classe-eleve-tile',
  templateUrl: './eleve-tile.component.html',
  animations: [eleveTileAnimations],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EleveTileComponent implements OnInit {


  private selectedSubject = new BehaviorSubject<boolean>(false);
  public selectedState$ = this.selectedSubject.asObservable();

  @Input() public eleve!: Eleve | null;
  @Input() public class!: string | null;
  @Input() public isSelectable: boolean = true;
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
    if (this.isSelectable) {
      this.selectedState$
        .pipe(take(1))
        .subscribe((selected: boolean) => {
          if (!selected) {
            this.selected.emit(this.eleve);
            this.selectedSubject.next(true)
          }
        });
    }
  }

  private unSelectEleve() {
    if (this.isSelectable) {
      this.selectedState$
        .pipe(take(1))
        .subscribe((selected: boolean) => {
          if (selected) {
            this.selectedSubject.next(false)
          }
        });
    }
  }
}
