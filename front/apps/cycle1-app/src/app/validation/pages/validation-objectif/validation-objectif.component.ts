import { FullSizeBaseComponent } from '@a3/shared-lib';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ValidationStore } from '../../store/validation.store';

@Component({
  selector: 'app-validation-objectif',
  templateUrl: './validation-objectif.component.html',
  styleUrls: ['./validation-objectif.component.scss']
})
export class ValidationObjectifComponent extends FullSizeBaseComponent implements OnInit {

  constructor(
    private readonly router: Router,
    private readonly acticatedRoute: ActivatedRoute,
    public readonly validationStore: ValidationStore
  ) {
    super()
    this.mettreAJourValidationStore();
  }


  private mettreAJourEleveValidationStore() {
    this.acticatedRoute.paramMap
      .subscribe((params) => {
        const eleveId = Number(params.get('eleveId'));
        this.validationStore.mettreAJourEleveParId(eleveId);
      });
  }

  private mettreAJourValidationStore() {
    this.acticatedRoute.paramMap
      .subscribe((params) => {
        const eleveId = Number(params.get('eleveId'));
        const objectifId = Number(params.get('objectifId'));
        this.validationStore.mettreAJourObjectifEleveParId(eleveId, objectifId);
      });
  }

  override ngOnInit(): void {
    super.ngOnInit();
    this.acticatedRoute.paramMap
      .subscribe((params) => {
        const eleveId = Number(params.get('eleveId'));
        this.validationStore.mettreAJourEleveParId(eleveId);
        const objectifId = Number(params.get('objectifId'));
        this.validationStore.mettreAJourObjectifEleveParId(eleveId, objectifId);
      });
  }

}
