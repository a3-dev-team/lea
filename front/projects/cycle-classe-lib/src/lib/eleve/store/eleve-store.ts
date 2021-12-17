import { Injectable } from '@angular/core';
import { shareReplay, Subject } from 'rxjs';
import { Eleve } from '../entities/eleve';
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

  constructor(private readonly eleveService: EleveService) { }

  public ajouterEleve(eleve: Eleve) {
    this.eleveService.ajouterEleve(eleve)
      .subscribe((eleveRetourne: Eleve) => {
        this.eleveAjouteSubject.next(eleveRetourne);
      });
  }

}
