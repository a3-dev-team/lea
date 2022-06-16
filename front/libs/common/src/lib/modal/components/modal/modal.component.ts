import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ModalManager } from '../../services/modal-manager.service';
import { modalAnimations } from './modal.animation';

@Component({
  selector: 'a3-modal',
  templateUrl: './modal.component.html',
  animations: [modalAnimations],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ModalComponent implements OnInit {

  private isVisibleSubject$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public isVisibleState$ = this.isVisibleSubject$.asObservable();

  @Input() public title: string | null = null;
  @Input() public widthInRem: number | null = null;
  @Input() public heightInRem: number | null = null;
  @Input() public widthInPourcentage: number | null = null;
  @Input() public heightInPourcentage: number | null = null;

  constructor(private readonly modalManager: ModalManager) { }

  ngOnInit(): void {
  }

  public show() {
    this.isVisibleSubject$.next(true);
  }

  public hide() {
    this.isVisibleSubject$.next(false);
  }

}
