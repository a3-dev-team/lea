import { Component, OnInit } from '@angular/core';
import { ApplicationStore } from '../../../core/application-store/application-store';

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html',
  styleUrls: ['./accueil.component.scss']
})
export class AccueilComponent implements OnInit {

  constructor(private readonly applicationStore: ApplicationStore) {
    this.desactiverModeEleve();
    this.applicationStore.mettreAJourTitre("Accueil");
  }

  ngOnInit(): void {
  }

  public onValidationEleveButtonClick(): void {
    this.activerModeEleve();
  }

  private activerModeEleve(): void {
    this.applicationStore.mettreAJourEstModeEleve(true);
  }

  private desactiverModeEleve(): void {
    this.applicationStore.mettreAJourEstModeEleve(false);
  }

}
