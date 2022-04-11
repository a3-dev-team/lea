import { ENVIRONMENT, IApiProperties, IEnvironment, UrlHelper } from '@a3/shared-lib';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiProperties } from '../../api-properties.model';
import { Professeur } from '../models/professeur.model';

@Injectable({
  providedIn: 'root'
})
export class ProfesseurService {

  private apiProperties: IApiProperties = new ApiProperties();
  private professeursUrl = `${UrlHelper.GetBackApiUrl(this.environment, this.apiProperties)}professeurs`;

  constructor(
    private readonly http: HttpClient,
    @Inject(ENVIRONMENT) private environment: IEnvironment
  ) { }

  public chargerProfesseurParEmail(email: string): Observable<Professeur> {
    return this.http.get<Professeur>(`${this.professeursUrl}/${email}`);
  }
}
