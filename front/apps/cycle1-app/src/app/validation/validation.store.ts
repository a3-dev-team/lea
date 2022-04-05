import { Injectable } from '@angular/core';
import { Eleve, EleveService } from '@cycle-classe-lib';
import { Objectif } from '@cycle1-objectif-lib';
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

  public MettreAJourEleve(eleve: Eleve | null) {
    this.eleveSubject.next(eleve);
  }

  public MettreAJourObjectif(objectif: Objectif | null) {
    this.objectifSubject.next(objectif);
  }

  public MettreAJourEleveParId(eleveId: number | null) {
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
          this.MettreAJourEleve(eleve);
        })
    }
    else {
      this.MettreAJourEleve(null);
    }
  }


}
