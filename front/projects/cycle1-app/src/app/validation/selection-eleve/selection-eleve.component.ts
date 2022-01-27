import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Eleve } from 'projects/cycle-classe-lib/src/lib/eleve/entities/eleve';
import { EleveStore } from 'projects/cycle-classe-lib/src/lib/eleve/store/eleve-store';
import { ApplicationStore } from './../../core/application-store/application-store';

@Component({
  selector: 'app-selection-eleve',
  templateUrl: './selection-eleve.component.html',
  styleUrls: ['./selection-eleve.component.scss']
})
export class SelectionEleveComponent {

  constructor(
    private readonly router: Router,
    private readonly applicationStore: ApplicationStore,
    public readonly eleveStore: EleveStore) {
    this.applicationStore.mettreAJourEleveSelectionne(null);
  }

  public onEleveSelection(eleve: Eleve) {
    this.applicationStore.mettreAJourEleveSelectionne(eleve);
    this.router.navigateByUrl(`/validation/eleves/${eleve.id}/objectifs`)
  }

}
