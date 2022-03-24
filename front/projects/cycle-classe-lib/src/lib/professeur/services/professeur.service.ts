import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlHelper } from 'projects/cycle1-app/src/app/core/helpers/url-helper';
import { Observable } from 'rxjs';
import { Professeur } from '../models/professeur.model';

@Injectable({
  providedIn: 'root'
})
export class ProfesseurService {

  private professeursUrl = UrlHelper.cycle1BackApiUrl + "professeurs";

  constructor(private readonly http: HttpClient) { }

  public chargerProfesseurParEmail(email: string): Observable<Professeur> {
    return this.http.get<Professeur>(`${this.professeursUrl}/${email}`);
  }
}
