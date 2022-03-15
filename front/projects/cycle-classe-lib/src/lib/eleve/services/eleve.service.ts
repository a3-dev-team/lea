import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Eleve } from '../models/eleve.model';
import { UrlHelper } from './../../../../../cycle1-app/src/app/core/helpers/url-helper';

@Injectable({
  providedIn: 'root'
})
export class EleveService {

  private elevesUrl = UrlHelper.cycle1BackApiUrl + "eleves";

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
  //   })
  // ])
  constructor(private readonly http: HttpClient) { }

  public ajouterEleve(eleve: Eleve): Observable<Eleve> {
    return this.http.post<Eleve>(this.elevesUrl, eleve);
  }
}
