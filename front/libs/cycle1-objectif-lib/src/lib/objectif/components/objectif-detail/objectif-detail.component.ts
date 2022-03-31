import { Component, Input, OnInit } from '@angular/core';
import { Objectif } from '../../models/objectif.model';

@Component({
  selector: 'lib-objectif-detail',
  templateUrl: './objectif-detail.component.html',
  styleUrls: ['./objectif-detail.component.scss'],
})
export class ObjectifDetailComponent implements OnInit {
  @Input() objectif!: Objectif;

  constructor() { }

  ngOnInit(): void { }
}
