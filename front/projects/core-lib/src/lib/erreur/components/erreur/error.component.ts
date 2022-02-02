import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { ErrorManager } from '../../services/error-manager.service';

@Component({
  selector: 'lib-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent implements OnInit {


  /**
   * Message d'erreur affichée ou non
   * @date 01/02/2022 - 18:00:05
   *
   * @private
   * @type {*}
   */
  private isErrorDisplayedSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public isErrorDisplayedState$ = this.isErrorDisplayedSubject.asObservable();


  constructor(private readonly errorManager: ErrorManager) { }

  ngOnInit(): void {
  }

  public errorThrowed$ = this.errorManager.errorThrowedAction$
    .pipe(
      tap(() => this.isErrorDisplayedSubject.next(true))
    )

  public onCloseClick() {
    this.isErrorDisplayedSubject.next(false);
  }

}
