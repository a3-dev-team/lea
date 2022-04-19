import { Eleve, EleveService } from '@a3/cycle-classe-lib';
import { Objectif } from '@a3/cycle1-objectif-lib';
import { Injectable } from '@angular/core';
import { BehaviorSubject, first, of, switchMap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ValidationStore {

  private eleveSubject = new BehaviorSubject<Eleve | null>(null);
  public eleveState$ = this.eleveSubject.asObservable();

  private objectifSubject = new BehaviorSubject<Objectif | null>(null);
  public objectifState$ = this.objectifSubject.asObservable();

  constructor(private readonly eleveService: EleveService) { }

  public mettreAJourEleve(eleve: Eleve | null) {
    this.eleveSubject.next(eleve);
  }

  public mettreAJourObjectif(objectif: Objectif | null) {
    this.objectifSubject.next(objectif);
  }

  public mettreAJourEleveParId(eleveId: number | null) {
    if (eleveId) {
      this.eleveState$
        .pipe(
          first(),
          switchMap((eleve: Eleve | null) => {
            if (!eleve || eleve.id !== eleveId) {
              return this.eleveService.chargerEleve(eleveId);
            }
            else {
              return of(eleve);
            }
          })
        )
        .subscribe((eleve: Eleve | null) => {
          this.mettreAJourEleve(eleve);
        })
    }
    else {
      this.mettreAJourEleve(null);
    }
  }


}
