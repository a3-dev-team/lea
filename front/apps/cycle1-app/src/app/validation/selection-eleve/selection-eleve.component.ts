import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Classe, Eleve, EleveService } from '@cycle-classe-lib';
import { first, mergeMap, of } from 'rxjs';
import { ApplicationStore } from '../../core/application-store/application-store';


@Component({
  selector: 'app-selection-eleve',
  templateUrl: './selection-eleve.component.html',
  styleUrls: ['./selection-eleve.component.scss']
})
export class SelectionEleveComponent {

  public listeEleveClasse$ =
    this.applicationStore.classeState$
      .pipe(
        first(),
        mergeMap((classe: Classe | null) => {
          if (classe) {
            return this.eleveService.chargerListeEleveClasse(classe.id)
          }
          else {
            return of([])
          }
        })
      );

  constructor(
    private readonly router: Router,
    private readonly applicationStore: ApplicationStore,
    public readonly eleveService: EleveService) {
  }

  public onEleveSelection(eleve: Eleve) {
    this.router.navigateByUrl(`/validation/eleves/${eleve.id}/objectifs`)
  }

}
