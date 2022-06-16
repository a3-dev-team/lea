import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, shareReplay, switchMap } from 'rxjs';
import { Eleve } from '../models/eleve.model';
import { EleveService } from '../services/eleve.service';

@Injectable({
  providedIn: 'root'
})
export class EleveCache {

  private updateCache$: BehaviorSubject<void> = new BehaviorSubject<void>(undefined);
  private cache: Map<number, Observable<Eleve[]>> = new Map<number, Observable<Eleve[]>>();

  constructor(private readonly eleveService: EleveService) { }

  public chargerListeEleveClasse(classeId: number): Observable<Eleve[]> {
    let cache$ = this.cache.get(classeId);
    if (!cache$) {
      cache$ = this.updateCache$
        .pipe(
          // On attend pas que la valeur précédente émise par updateCache$ soit retournée pour déclenchée la suivante, 
          // et on écoute pas le retour de la précédente
          switchMap(() => { return this.eleveService.chargerListeEleveClasse(classeId) }),
          shareReplay(1)
        );
      this.cache.set(classeId, cache$);
    }
    return cache$;
  }

  public updateCache() {
    this.updateCache$.next();
  }

}
