import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map, Observable } from 'rxjs';
import { ApplicationStore } from '../../core/application-store/application-store';

// Empêche de sortie du module validation. Empêche les élèves de revenir sur l'accueil, login...
@Injectable({
  providedIn: 'root'
})
export class ValidationGuard implements CanDeactivate<unknown> {

  constructor(private readonly applicationStore: ApplicationStore) { }

  canDeactivate(
    component: unknown,
    currentRoute: ActivatedRouteSnapshot,
    currentState: RouterStateSnapshot,
    nextState?: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.applicationStore.estModeEleveState$.pipe(
      map((estModeEleve) => !estModeEleve)
    );
  }

}
