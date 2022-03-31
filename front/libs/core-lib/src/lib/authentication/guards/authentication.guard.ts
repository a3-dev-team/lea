import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, CanLoad, Route, Router, RouterStateSnapshot, UrlSegment, UrlTree } from '@angular/router';
import { map, Observable, tap } from 'rxjs';
import { IAuthenticatedUser } from '../models/authenticated-user.model';
import { AuthenticationManager } from '../services/authentication-manager.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate, CanActivateChild, CanLoad {



  /**
   * Indique si un utilisateur est authentifié
   * @date 01/02/2022 - 11:28:28
   *
   * @private
   * @type {*}
   */
  private isUserSignedIn$: Observable<boolean> = this.authenticationManager.authenticatedUserState$
    .pipe(
      map((authenticatedUser: IAuthenticatedUser | null) => !!authenticatedUser),
    );

  constructor(
    private readonly router: Router,
    private readonly authenticationManager: AuthenticationManager) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.isUserSignedIn$.pipe(
      tap((isUserSignedIn: boolean) => {
        if (!isUserSignedIn) {
          this.router.navigate(['/signIn'], { queryParams: { urlRedirection: state.url } });
        }
      })
    );
  }
  canActivateChild(
    childRoute: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.isUserSignedIn$.pipe(
      tap((isUserSignedIn: boolean) => {
        if (!isUserSignedIn) {
          this.router.navigate(['/signIn'], { queryParams: { urlRedirection: state.url } });
        }
      })
    );
  }
  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.isUserSignedIn$;
  }



}
