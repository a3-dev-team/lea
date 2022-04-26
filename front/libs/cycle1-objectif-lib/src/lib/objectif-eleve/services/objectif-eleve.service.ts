import { ENVIRONMENT, IApiProperties, IEnvironment, UrlHelper } from '@a3/shared-lib';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiProperties } from '../../api-properties.model';
import { ObjectifEleve } from '../models/objectif-eleve.model';

@Injectable({
  providedIn: 'root',
})
export class ObjectifEleveService {
  private apiProperties: IApiProperties = new ApiProperties();
  private objectifsUrl = `${UrlHelper.GetBackApiUrl(this.environment, this.apiProperties)}objectifs-eleve`;

  constructor(
    private readonly http: HttpClient,
    @Inject(ENVIRONMENT) private environment: IEnvironment
  ) { }

  public chargerObjectifEleve(eleveId: number, objectifId: number): Observable<ObjectifEleve> {
    return this.http.get<ObjectifEleve>(`${UrlHelper.GetBackApiUrl(this.environment, this.apiProperties)}eleves/${eleveId}/objectifs/${objectifId}`);
  }
}