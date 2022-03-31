import { Component, OnInit } from '@angular/core';
import { ObjectifStore } from '@cycle1-objectif-lib';

@Component({
  selector: 'app-selection-objectif',
  templateUrl: './selection-objectif.component.html',
  styleUrls: ['./selection-objectif.component.scss'],
})
export class SelectionObjectifComponent implements OnInit {
  constructor(public readonly objectifStore: ObjectifStore) { }

  ngOnInit(): void { }
}
