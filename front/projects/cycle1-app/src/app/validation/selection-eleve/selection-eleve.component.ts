import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Eleve } from 'projects/cycle-classe-lib/src/lib/eleve/models/eleve.model';
import { EleveStore } from 'projects/cycle-classe-lib/src/lib/eleve/store/eleve-store';

@Component({
  selector: 'app-selection-eleve',
  templateUrl: './selection-eleve.component.html',
  styleUrls: ['./selection-eleve.component.scss']
})
export class SelectionEleveComponent {

  constructor(
    private readonly router: Router,
    public readonly eleveStore: EleveStore) {
  }

  public onEleveSelection(eleve: Eleve) {
    this.router.navigateByUrl(`/validation/eleves/${eleve.id}/objectifs`)
  }

}
