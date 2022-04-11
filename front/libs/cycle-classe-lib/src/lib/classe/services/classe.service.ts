import { ENVIRONMENT, IApiProperties, IEnvironment, UrlHelper } from '@a3/shared-lib';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiProperties } from '../../api-properties.model';
import { Classe } from '../models/classe.model';

@Injectable({
  providedIn: 'root'
})
export class ClasseService {

  private apiProperties: IApiProperties = new ApiProperties();
  private classesUrl = `${UrlHelper.GetBackApiUrl(this.environment, this.apiProperties)}classes`;

  constructor(
    private readonly http: HttpClient,
    @Inject(ENVIRONMENT) private environment: IEnvironment
  ) { }

  public chargerClasse(classeId: number): Observable<Classe> {
    return this.http.get<Classe>(`${this.classesUrl}/${classeId}`)
  }
}
