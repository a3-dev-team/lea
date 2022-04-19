import { BaseComponent } from '@a3/shared-lib';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { QrcodeObjectifHelper } from '../../helpers/qrcode-objectif.helper';
import { Objectif } from '../../models/objectif.model';

@Component({
  selector: 'a3-objectif-liste',
  templateUrl: './objectif-liste.component.html',
  styleUrls: ['./objectif-liste.component.scss'],
})
export class ObjectifListeComponent extends BaseComponent implements OnInit {

  @Input() public objectifs$!: Observable<Objectif[]>;

  public QrcodeObjectifHelper: typeof QrcodeObjectifHelper = QrcodeObjectifHelper

  constructor() {
    super()
  }

}
