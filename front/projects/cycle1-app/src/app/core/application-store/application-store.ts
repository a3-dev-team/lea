import { Injectable } from '@angular/core';
import { Eleve } from 'projects/cycle-classe-lib/src/lib/eleve/entities/eleve';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})



export class ApplicationStore {

  private estModeValidationActifSubject = new BehaviorSubject<boolean>(false);
  public estModeValidationActifState$ = this.estModeValidationActifSubject.asObservable();

  private eleveSelectionneSubject = new BehaviorSubject<Eleve | null>(null);
  public eleveSelectionneState$ = this.eleveSelectionneSubject.asObservable();

  private erreurLeveeSubject = new Subject<string>();
  public erreurLeveeAction$ = this.erreurLeveeSubject.asObservable();

  constructor() { }

  public mettreAJourEstModeValidationActif(estModeValidationActif: boolean) {
    this.estModeValidationActifSubject.next(estModeValidationActif);
  }

  public mettreAJourEleveSelectionne(eleve: Eleve | null) {
    this.eleveSelectionneSubject.next(eleve);
  }

  public leverErreur(erreur: string) {
    this.erreurLeveeSubject.next(erreur);
  }

}
