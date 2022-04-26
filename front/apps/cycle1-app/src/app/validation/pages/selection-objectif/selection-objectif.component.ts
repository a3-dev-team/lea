import { FullSizeBaseComponent } from '@a3/shared-lib';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QrcodeObjectifHelper } from 'libs/cycle1-objectif-lib/src/lib/objectif/helpers/qrcode-objectif.helper';
import { ValidationStore } from '../../store/validation.store';


@Component({
  selector: 'app-selection-objectif',
  templateUrl: './selection-objectif.component.html',
  styleUrls: ['./selection-objectif.component.scss'],
})
export class SelectionObjectifComponent extends FullSizeBaseComponent implements OnInit {
  constructor(
    private readonly router: Router,
    private readonly acticatedRoute: ActivatedRoute,
    public readonly validationStore: ValidationStore) {
    super();
    this.validationStore.mettreAJourObjectifEleve(null);
  }

  public override ngOnInit(): void {
    super.ngOnInit();
    this.acticatedRoute.paramMap
      .subscribe((params) => {
        const eleveId = Number(params.get('eleveId'));
        this.validationStore.mettreAJourEleveParId(eleveId);
      });
  }

  onQrcodeReaderStringScanned(stringScanned: string) {
    const objectifEleveId: number | null = QrcodeObjectifHelper.obtenirObjectifIdDepuisQrcode(stringScanned)
    if (objectifEleveId) {
      this.acticatedRoute.paramMap
        .subscribe((params) => {
          const eleveId = Number(params.get('eleveId'));
          this.router.navigateByUrl(`/validation/eleves/${eleveId}/objectifs/${objectifEleveId}`, { replaceUrl: true });
        });
    }
  }

}
