import { Injectable } from '@angular/core';
import { shareReplay, Subject } from 'rxjs';
import { Objectif } from '../models/objectif.model';
import { ObjectifService } from '../services/objectif.service';

@Injectable({
  providedIn: 'root',
})
export class ObjectifStore {
  private objectifAjouteSubject = new Subject<Objectif>();
  public objectifAjouteAction$ = this.objectifAjouteSubject.asObservable();

  public objectifs$ = this.objectifService.objectifs$.pipe(shareReplay(1));

  constructor(private readonly objectifService: ObjectifService) { }

  public ajouterObjectif(objectif: Objectif) {
    this.objectifService
      .ajouterObjectif(objectif)
      .subscribe((objectifRetourne: Objectif) => {
        this.objectifAjouteSubject.next(objectifRetourne);
      });
  }
}
