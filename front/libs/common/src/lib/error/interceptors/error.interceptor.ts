import {
  HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, EMPTY, Observable, throwError } from 'rxjs';
import { AuthenticationManager } from '../../authentication/services/authentication-manager.service';
import { ErrorManager } from '../services/error-manager.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private readonly errorManager: ErrorManager,
    private readonly authenticationManager: AuthenticationManager) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      // retry(1),
      catchError((error: HttpErrorResponse) => {
        console.warn(error);
        switch (error.status) {
          case 401:
            this.authenticationManager.signOut();
            this.errorManager.throwError("Echec de l'authentification");
            return EMPTY;
          default:
            this.errorManager.throwError(error.message);
            return throwError(() => error);
        }
      })
    );
  }
}
