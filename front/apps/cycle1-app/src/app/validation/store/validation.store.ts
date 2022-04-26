import { Eleve, EleveService } from '@a3/cycle-classe-lib';
import { ObjectifEleve, ObjectifEleveService } from '@a3/cycle1-objectif-lib';
import { Injectable } from '@angular/core';
import { BehaviorSubject, first, of, switchMap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ValidationStore {

  private eleveSubject = new BehaviorSubject<Eleve | null>(null);
  public eleveState$ = this.eleveSubject.asObservable();

  private objectifEleveSubject = new BehaviorSubject<ObjectifEleve | null>(null);
  public objectifEleveState$ = this.objectifEleveSubject.asObservable();

  constructor(
    private readonly eleveService: EleveService,
    private readonly objectifEleveService: ObjectifEleveService
  ) { }

  public mettreAJourEleve(eleve: Eleve | null) {
    this.eleveSubject.next(eleve);
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

  public mettreAJourObjectifEleve(objectifEleve: ObjectifEleve | null) {
    this.objectifEleveSubject.next(objectifEleve);
  }

  public mettreAJourObjectifEleveParId(eleveId: number | null, objectifId: number | null) {
    if (eleveId && objectifId) {
      this.objectifEleveState$
        .pipe(
          first(),
          switchMap((objectifEleve: ObjectifEleve | null) => {
            if (!objectifEleve || objectifEleve.eleveId !== eleveId || objectifEleve.objectifId !== objectifId) {
              return this.objectifEleveService.chargerObjectifEleve(eleveId, objectifId);
            }
            else {
              return of(objectifEleve);
            }
          })
        )
        .subscribe((objectifEleve: ObjectifEleve | null) => {
          this.mettreAJourObjectifEleve(objectifEleve);
        })
    }
    else {
      this.mettreAJourObjectifEleve(null);
    }
  }


}
