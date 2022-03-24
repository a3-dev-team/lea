import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlHelper } from 'projects/cycle1-app/src/app/core/helpers/url-helper';
import { Observable } from 'rxjs';
import { Classe } from '../models/classe.model';

@Injectable({
  providedIn: 'root'
})
export class ClasseService {

  private classesUrl = UrlHelper.cycle1BackApiUrl + "classes";

  constructor(private readonly http: HttpClient) { }

  public chargerClasse(classeId: number): Observable<Classe> {
    return this.http.get<Classe>(`${this.classesUrl}/${classeId}`)
  }
}
