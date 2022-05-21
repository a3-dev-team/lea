import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorManager {


  /**
   * Erreur levée dans l'application
   * @date 01/02/2022 - 11:55:58
   *
   * @private
   * @type {*}
   */
  private errorThrowedSubject = new Subject<string | null>();
  public errorThrowedAction$ = this.errorThrowedSubject.asObservable();

  constructor() { }


  /**
   * Lève une erreur dans l'application
   * @date 01/02/2022 - 11:55:24
   *
   * @param {(string | null)} error
   */
  throwError(error: string | null) {
    this.errorThrowedSubject.next(error);
  }
}
