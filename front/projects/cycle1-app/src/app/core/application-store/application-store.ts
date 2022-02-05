import { Injectable } from '@angular/core';
import { Eleve } from 'projects/cycle-classe-lib/src/lib/eleve/entities/eleve';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})



export class ApplicationStore {



  private estModeValidationActifSubject = new BehaviorSubject<boolean>(false);
  public estModeValidationActifState$ = this.estModeValidationActifSubject.asObservable();

  private eleveSelectionneSubject = new BehaviorSubject<Eleve | null>(null);
  public eleveSelectionneState$ = this.eleveSelectionneSubject.asObservable();

  constructor() { }

  public MettreAJourEstModeValidationActif(estModeValidationActif: boolean) {
    this.estModeValidationActifSubject.next(estModeValidationActif);
  }

  public MettreAJourEleveSelectionne(eleve: Eleve | null) {
    this.eleveSelectionneSubject.next(eleve);
  }

}
