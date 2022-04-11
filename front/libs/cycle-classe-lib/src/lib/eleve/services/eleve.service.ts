import { ENVIRONMENT, IApiProperties, IEnvironment, UrlHelper } from '@a3/shared-lib';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { ApiProperties } from '../../api-properties.model';
import { Eleve } from '../models/eleve.model';

@Injectable({
  providedIn: 'root'
})
export class EleveService {

  private apiProperties: IApiProperties = new ApiProperties();
  private elevesUrl = `${UrlHelper.GetBackApiUrl(this.environment, this.apiProperties)}eleves`;

  public eleves$ = this.http.get<Eleve[]>(this.elevesUrl)
    .pipe(
      catchError((error) => {
        console.log(error);
        return throwError(() => error);
      })
    )
  // eleves$ = of([
  //   new Eleve({
  //     dateNaissance: new Date(2018, 1, 1),
  //     prenom: "Tito",
  //     emails: ["pablitoFamily@yahoo.Fr"],
  //     id: 1,
  //     nom: "PABLO"
  //   }),
  //   new Eleve({
  //     dateNaissance: new Date(2018, 1, 1),
  //     prenom: "Tito",
  //     emails: ["pablitoFamily@yahoo.Fr"],
  //     id: 2,
  //     nom: "PABLO"
  //   })
  // ])
  constructor(
    private readonly http: HttpClient,
    @Inject(ENVIRONMENT) private environment: IEnvironment
  ) { }

  public ajouterEleve(eleve: Eleve): Observable<Eleve> {
    return this.http.post<Eleve>(this.elevesUrl, eleve);
  }

  public chargerListeEleveClasse(classeId: number): Observable<Eleve[]> {
    return this.http.get<Eleve[]>(`${UrlHelper.GetBackApiUrl(this.environment, this.apiProperties)}classes/${classeId}/eleves`);
  }

  public chargerEleve(eleveId: number): Observable<Eleve> {
    return this.http.get<Eleve>(`${UrlHelper.GetBackApiUrl(this.environment, this.apiProperties)}eleves/${eleveId}`);
  }


}
