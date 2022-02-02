import {
  HttpEvent, HttpHandler, HttpInterceptor, HttpRequest
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { finalize, Observable } from 'rxjs';
import { LoaderManager } from '../services/loader-manager.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {

  constructor(private readonly loaderManager: LoaderManager) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    // On affiche le loader avant de lancer la requête vers la WebAPI
    this.loaderManager.showLoader();
    return next.handle(request).pipe(
      // On cache le loader une fois que la requête vers la WebAPI est terminée
      finalize(() => this.loaderManager.hideLoader())
    );
  }
}
