import { Injectable } from '@angular/core';
import { Classe } from '@cycle-classe-lib';
import { Professeur } from 'projects/cycle-classe-lib/src/lib/professeur/models/professeur.model';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})



export class ApplicationStore {

  private professeurSubject = new BehaviorSubject<Professeur | null>(null);
  public professeurState$ = this.professeurSubject.asObservable();

  private classeSubject = new BehaviorSubject<Classe | null>(null);
  public classeState$ = this.classeSubject.asObservable();

  constructor() { }

  public MettreAJourProfesseur(professeur: Professeur | null) {
    this.professeurSubject.next(professeur);
  }

  public MettreAJourClasse(classe: Classe | null) {
    this.classeSubject.next(classe);
  }

}
