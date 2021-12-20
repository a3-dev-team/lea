import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Eleve } from '../entities/eleve';
import { UrlHelper } from './../../../../../cycle1-app/src/app/core/helpers/url-helper';

@Injectable({
  providedIn: 'root'
})
export class EleveService {

  private elevesUrl = UrlHelper.backApiUrl + "/eleves";

  public eleves$ = this.http.get<Eleve[]>(this.elevesUrl)
    .pipe(
      catchError((error) => {
        console.log(error);
        return throwError(() => error);
      })
    )


  constructor(private readonly http: HttpClient) { }

  public ajouterEleve(eleve: Eleve): Observable<Eleve> {
    return this.http.post<Eleve>(this.elevesUrl, eleve);
  }
}
