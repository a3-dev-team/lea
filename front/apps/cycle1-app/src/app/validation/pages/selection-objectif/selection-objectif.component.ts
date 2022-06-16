import { Eleve } from '@a3/cycle-classe-lib';
import { ObjectifEleve, ObjectifEleveCache } from '@a3/cycle1-objectif-lib';
import { FullSizeBaseComponent } from '@a3/shared-lib';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QrcodeObjectifHelper } from 'libs/cycle1-objectif-lib/src/lib/objectif/helpers/qrcode-objectif.helper';
import { first, mergeMap, of } from 'rxjs';
import { ValidationStore } from '../../store/validation.store';


@Component({
  selector: 'app-selection-objectif',
  templateUrl: './selection-objectif.component.html',
  styleUrls: ['./selection-objectif.component.scss'],
})
export class SelectionObjectifComponent extends FullSizeBaseComponent implements OnInit {

  public listeObjectifEleve$ =
    this.validationStore.eleveState$
      .pipe(
        first(eleve => !!eleve),
        mergeMap((eleve: Eleve | null) => {
          if (eleve) {
            return this.objectiEleveCahce.chargerListeObjectifEleve(eleve.id)
          }
          else {
            return of([])
          }
        })
      );

  constructor(
    private readonly router: Router,
    private readonly acticatedRoute: ActivatedRoute,
    public readonly validationStore: ValidationStore,
    private readonly objectiEleveCahce: ObjectifEleveCache) {
    super();
    this.validationStore.mettreAJourObjectifEleve(null);
  }

  public override ngOnInit(): void {
    super.ngOnInit();
    this.mettreAJourEleveValidationStore();
  }

  private mettreAJourEleveValidationStore() {
    this.acticatedRoute.paramMap
      .subscribe((params) => {
        const eleveId = Number(params.get('eleveId'));
        this.validationStore.mettreAJourEleveParId(eleveId);
      });
  }

  public onQrcodeReaderStringScanned(stringScanned: string) {
    const objectifId: number | null = QrcodeObjectifHelper.obtenirObjectifIdDepuisQrcode(stringScanned)
    if (objectifId) {
      this.navigate(objectifId);
    }
  }

  public onSelectedObjectifEleve(objectifEleve: ObjectifEleve): void {
    this.navigate(objectifEleve.objectifId);
  }

  private navigate(objectifId: number) {
    this.acticatedRoute.paramMap
      .subscribe((params) => {
        const eleveId = Number(params.get('eleveId'));
        this.router.navigateByUrl(`/validation/eleves/${eleveId}/objectifs/${objectifId}`, { replaceUrl: true });
      });
  }

}
