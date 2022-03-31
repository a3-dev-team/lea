import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Objectif } from '../../models/objectif.model';

@Component({
  selector: 'cycle1-obectif-liste',
  templateUrl: './objectif-liste.component.html',
  styleUrls: ['./objectif-liste.component.scss'],
})
export class ObjectifListeComponent implements OnInit {
  @Input() public objectifs$!: Observable<Objectif[]>;

  constructor() { }

  ngOnInit(): void { }
}
