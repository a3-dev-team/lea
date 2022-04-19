import { Classe, Eleve, EleveService } from '@a3/cycle-classe-lib';
import { FullSizeBaseComponent } from '@a3/shared-lib';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { first, mergeMap, of } from 'rxjs';
import { ApplicationStore } from '../../../core/application-store/application-store';
import { ValidationStore } from '../../store/validation.store';


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
    public readonly applicationStore: ApplicationStore,
    private readonly validationStore: ValidationStore,
    public readonly eleveService: EleveService) {
    super();
    this.validationStore.mettreAJourEleve(null);
  }

  public onEleveSelected(eleve: Eleve) {
    this.validationStore.mettreAJourEleve(eleve);
    this.router.navigateByUrl(`/validation/eleves/${eleve.id}/objectifs`, { replaceUrl: true });
  }

}
