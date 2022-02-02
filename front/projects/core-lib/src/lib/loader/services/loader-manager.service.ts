import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoaderManager {

  /**
 * Affichage du loader
 * @date 01/02/2022 - 11:55:58
 *
 * @private
 * @type {*}
 */
  private isLoadingSubject = new BehaviorSubject<boolean>(false);
  public isLoadingState$ = this.isLoadingSubject.asObservable();

  constructor() { }


  /**
   * Compteur permettant des gérers les demandes d'affichage en parallèle
   * @date 01/02/2022 - 12:17:01
   *
   * @private
   * @type {number}
   */
  private loadingIndex = 0;

  /**
   * Affiche le "loader" de chargement
   * @date 01/02/2022 - 12:16:05
   *
   * @public
   */
  public showLoader() {
    this.loadingIndex += 1;
    if (this.loadingIndex = 1) {
      this.isLoadingSubject.next(true);
    }
  }

  /**
   * Cache le "loader" de chargement
   * @date 01/02/2022 - 12:16:31
   *
   * @public
   */
  public hideLoader() {
    this.loadingIndex -= 1;
    if (this.loadingIndex == 0) {
      this.isLoadingSubject.next(false);
    }
  }

}
