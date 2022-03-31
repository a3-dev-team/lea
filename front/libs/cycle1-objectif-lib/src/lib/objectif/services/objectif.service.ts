import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ENVIRONMENT, IApiProperties, IEnvironment, UrlHelper } from '@shared-lib';
import { catchError, Observable, throwError } from 'rxjs';
import { ApiProperties } from '../../api-properties.model';
import { Objectif } from '../models/objectif.model';

@Injectable({
  providedIn: 'root',
})
export class ObjectifService {
  private apiProperties: IApiProperties = new ApiProperties();
  private objectifsUrl = `${UrlHelper.GetBackApiUrl(this.environment, this.apiProperties)}objectifs`;

  public objectifs$ = this.http.get<Objectif[]>(this.objectifsUrl).pipe(
    catchError((error) => {
      console.log(error);
      return throwError(() => error);
    })
  );

  constructor(
    private readonly http: HttpClient,
    @Inject(ENVIRONMENT) private environment: IEnvironment
  ) { }

  public ajouterObjectif(objectif: Objectif): Observable<Objectif> {
    return this.http.post<Objectif>(this.objectifsUrl, objectif);
  }
}
