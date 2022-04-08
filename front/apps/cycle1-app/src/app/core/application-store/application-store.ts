import { Injectable } from '@angular/core';
import { Classe, Professeur } from '@cycle-classe-lib';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})



export class ApplicationStore {


  // Indique si l'application est en mode "pour les élèves"
  // Dans ce cas, il n'est pas possible de sortir de la validation
  private estModeEleveSubject = new BehaviorSubject<boolean>(false);
  public estModeEleveState$ = this.estModeEleveSubject.asObservable();

  private professeurSubject = new BehaviorSubject<Professeur | null>(null);
  public professeurState$ = this.professeurSubject.asObservable();

  private classeSubject = new BehaviorSubject<Classe | null>(null);
  public classeState$ = this.classeSubject.asObservable();

  constructor() { }

  public mettreAJourProfesseur(professeur: Professeur | null) {
    this.professeurSubject.next(professeur);
  }

  public mettreAJourClasse(classe: Classe | null) {
    this.classeSubject.next(classe);
  }

  public mettreAJourEstModeEleve(estModeEleve: boolean) {
    this.estModeEleveSubject.next(estModeEleve);
  }

}
