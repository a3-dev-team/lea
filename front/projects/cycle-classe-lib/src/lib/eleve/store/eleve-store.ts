import { Injectable } from '@angular/core';
import { merge, scan, shareReplay, Subject } from 'rxjs';
import { Eleve } from '../models/eleve.model';
import { EleveService } from './../services/eleve.service';

@Injectable({
  providedIn: 'root'
})
export class EleveStore {

  private eleveAjouteSubject = new Subject<Eleve>();
  public eleveAjouteAction$ = this.eleveAjouteSubject.asObservable();

  public eleves$ = this.eleveService.eleves$
    .pipe(
      shareReplay(1)
    )

  public elevesAvecAjouts = merge(
    this.eleves$,
    this.eleveAjouteAction$
  ).pipe(
    scan((acc: Eleve | Eleve[], value: Eleve | Eleve[]) => [...(acc as Eleve[]), (value as Eleve)])
  )

  constructor(private readonly eleveService: EleveService) { }

  public ajouterEleve(eleve: Eleve) {
    this.eleveService.ajouterEleve(eleve)
      .subscribe((eleveRetourne: Eleve) => {
        this.eleveAjouteSubject.next(eleveRetourne);
      });
  }

}