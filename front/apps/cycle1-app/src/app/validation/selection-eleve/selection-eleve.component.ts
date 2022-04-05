import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Classe, Eleve, EleveService } from '@cycle-classe-lib';
import { FullSizeBaseComponent } from '@shared-lib';
import { first, mergeMap, of } from 'rxjs';
import { ApplicationStore } from '../../core/application-store/application-store';
import { ValidationStore } from '../validation.store';


@Component({
  selector: 'app-selection-eleve',
  templateUrl: './selection-eleve.component.html',
  styleUrls: ['./selection-eleve.component.scss']
})
export class SelectionEleveComponent extends FullSizeBaseComponent {

  public listeEleveClasse$ =
    this.applicationStore.classeState$
      .pipe(
        first(classe => !!classe),
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
    private readonly validationStore: ValidationStore,
    public readonly eleveService: EleveService) {
    super();
    this.validationStore.MettreAJourEleve(null);
  }

  public onEleveSelected(eleve: Eleve) {
    this.validationStore.MettreAJourEleve(eleve);
    this.router.navigateByUrl(`/validation/eleves/${eleve.id}/objectifs`);
  }

}
