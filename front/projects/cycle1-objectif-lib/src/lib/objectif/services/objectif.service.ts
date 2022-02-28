import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Objectif } from '../entities/objectif';
import { UrlHelper } from './../../../../../cycle1-app/src/app/core/helpers/url-helper';

@Injectable({
  providedIn: 'root',
})
export class ObjectifService {
  private objectifsUrl = UrlHelper.cycle1BackApiUrl + '/objectifs';

  public objectifs$ = this.http.get<Objectif[]>(this.objectifsUrl).pipe(
    catchError((error) => {
      console.log(error);
      return throwError(() => error);
    })
  );

  constructor(private readonly http: HttpClient) { }

  public ajouterObjectif(objectif: Objectif): Observable<Objectif> {
    return this.http.post<Objectif>(this.objectifsUrl, objectif);
  }
}
