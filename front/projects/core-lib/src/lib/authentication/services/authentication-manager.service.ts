import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { UrlHelper } from 'projects/cycle1-app/src/app/core/helpers/url-helper';
import { environment } from 'projects/cycle1-app/src/environments/environment';
import { BehaviorSubject } from 'rxjs';
import { IAuthenticatedUser } from '../models/authenticated-user.model';
import { UserSignIn } from '../models/user-sign-in.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationManager {

  /**
   * Utilisateur connecté
   * @date 01/02/2022 - 10:22:15
   *
   * @private
   * @type {UserSignIn}
   */
  private userSignedInSubject = new BehaviorSubject<IAuthenticatedUser | null>(null);
  public userSignedInState$ = this.userSignedInSubject.asObservable();

  /**
   * Sous-Url vers le controlleur d'authentification
   * @date 01/02/2022 - 10:21:49
   *
   * @private
   * @type {string}
   */
  private webApiUrl = UrlHelper.backApiUrl + "users/signin"

  constructor(
    private readonly httpClient: HttpClient,
    private readonly router: Router) { }


  /**
   * Authentification d'un utilisateur
   * @date 01/02/2022 - 10:20:37
   *
   * @public
   * @param {UserSignIn} userSignedIn
   * @param {string} routeToNavigate
   */
  public signIn(userSignedIn: UserSignIn, routeToNavigate: string) {
    this.httpClient.post<IAuthenticatedUser>(this.webApiUrl, userSignedIn)
      .subscribe((authenticatedUser: IAuthenticatedUser) => {
        this.saveToken(authenticatedUser.token);
        this.userSignedInSubject.next(authenticatedUser);
        this.router.navigateByUrl(routeToNavigate);
      });
  }

  public signOut() {
    this.userSignedInSubject.next(null);
    this.deleteToken();
    this.router.navigate(["signIn"])
  }


  /**
   * Sauvegarde le token dans le LocalStorage
   * @date 01/02/2022 - 10:21:15
   *
   * @private
   * @param {string} jetonAuthentication
   */
  private saveToken(jetonAuthentication: string) {
    localStorage.setItem(environment.tokenName, jetonAuthentication);
  }


  /**
   * Suppression du token dans le LocalStorage
   * @date 01/02/2022 - 11:22:21
   *
   * @private
   */
  private deleteToken() {
    localStorage.removeItem(environment.tokenName);
  }


}
