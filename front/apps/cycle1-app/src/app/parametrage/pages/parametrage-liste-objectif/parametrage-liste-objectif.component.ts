import { ObjectifStore } from '@a3/cycle1-objectif-lib';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'cycle1-parametrage-liste-objectif',
  templateUrl: './parametrage-liste-objectif.component.html',
  styleUrls: ['./parametrage-liste-objectif.component.scss']
})
export class ParametrageListeObjectifComponent implements OnInit {

  constructor(public readonly objectifStore: ObjectifStore) { }

  ngOnInit(): void {
  }

}
