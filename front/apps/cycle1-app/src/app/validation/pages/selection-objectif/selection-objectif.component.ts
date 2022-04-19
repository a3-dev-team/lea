import { ObjectifStore } from '@a3/cycle1-objectif-lib';
import { FullSizeBaseComponent } from '@a3/shared-lib';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ValidationStore } from '../../store/validation.store';


@Component({
  selector: 'app-selection-objectif',
  templateUrl: './selection-objectif.component.html',
  styleUrls: ['./selection-objectif.component.scss'],
})
export class SelectionObjectifComponent extends FullSizeBaseComponent implements OnInit {
  constructor(
    private readonly acticatedRoute: ActivatedRoute,
    public readonly validationStore: ValidationStore,
    public readonly objectifStore: ObjectifStore) {
    super();
  }

  public override ngOnInit(): void {
    super.ngOnInit();
    this.acticatedRoute.paramMap
      .subscribe((params) => {
        const eleveId = Number(params.get('eleveId'));
        this.validationStore.mettreAJourEleveParId(eleveId);
      });
  }

}
