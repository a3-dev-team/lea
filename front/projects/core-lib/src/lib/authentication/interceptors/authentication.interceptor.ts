import {
  HttpEvent, HttpHandler, HttpInterceptor, HttpRequest
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'projects/cycle1-app/src/environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const authenticationToken: string | null = this.loadToken();
    if (!!authenticationToken) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${authenticationToken}`
        }
      });
    }
    return next.handle(request);
  }


  /**
   * Charge le token depuis le LocalStorage
   * @date 01/02/2022 - 11:30:21
   *
   * @private
   * @returns {string}
   */
  private loadToken(): string | null {
    return localStorage.getItem(environment.tokenName)
  }
}
