import { Injectable } from '@angular/core';
import { BehaviorSubject, merge, scan, shareReplay, Subject, switchMap } from 'rxjs';
import { Eleve } from '../models/eleve.model';
import { EleveService } from '../services/eleve.service';

@Injectable({
  providedIn: 'root'
})
export class EleveStore {

  private eleveAjouteSubject = new Subject<Eleve>();
  public eleveAjouteAction$ = this.eleveAjouteSubject.asObservable();

  private updateCache$: BehaviorSubject<void> = new BehaviorSubject<void>(undefined);

  public eleves$ = this.updateCache$
    .pipe(
      // On attend pas que la valeur précédente émise par updateCache$ soit retournée pour déclenchée la suivante, 
      // et on écoute pas le retour de la précédente
      switchMap(() => { return this.eleveService.eleves$ }),
      shareReplay(1)
    );

  public elevesAvecAjouts = merge(
    this.eleves$,
    this.eleveAjouteAction$
  ).pipe(
    scan((acc: Eleve | Eleve[], value: Eleve | Eleve[]) => [...(acc as Eleve[]), (value as Eleve)])
  )

  constructor(private readonly eleveService: EleveService) { }

  public ajouterEleve(eleve: Eleve) {
    this.eleveService.ajouterEleve(eleve)
      .subscribe((eleveRetourne: Eleve) => {
        this.eleveAjouteSubject.next(eleveRetourne);
      });
  }

  public updateCache() {
    this.updateCache$.next();
  }

}