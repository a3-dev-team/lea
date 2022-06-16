import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, shareReplay, switchMap } from 'rxjs';
import { ObjectifEleve } from '../models/objectif-eleve.model';
import { ObjectifEleveService } from '../services/objectif-eleve.service';

@Injectable({
  providedIn: 'root'
})
export class ObjectifEleveCache {

  private updateCache$: BehaviorSubject<void> = new BehaviorSubject<void>(undefined);
  private cache: Map<number, Observable<ObjectifEleve[]>> = new Map<number, Observable<ObjectifEleve[]>>();

  // public ojbectifsEleve$ = this.updateCache$
  //   .pipe(
  //     // On attend pas que la valeur précédente émise par updateCache$ soit retournée pour déclenchée la suivante, 
  //     // et on écoute pas le retour de la précédente
  //     switchMap(() => { return this.objectifEleveService.chargerObjectifEleve$() }),
  //     shareReplay(1)
  //   );

  constructor(private readonly objectifEleveService: ObjectifEleveService) { }

  public chargerListeObjectifEleve(eleveId: number): Observable<ObjectifEleve[]> {
    let cache$ = this.cache.get(eleveId);
    if (!cache$) {
      cache$ = this.updateCache$
        .pipe(
          // On attend pas que la valeur précédente émise par updateCache$ soit retournée pour déclenchée la suivante, 
          // et on écoute pas le retour de la précédente
          switchMap(
            () => this.objectifEleveService.chargerListeObjectifEleve(eleveId)
          ),
          shareReplay(1)
        );
      this.cache.set(eleveId, cache$);
    }
    return cache$;
  }

  public chargerObjectifEleve(eleveId: number, objectifId: number): Observable<ObjectifEleve | null> {
    return this.chargerListeObjectifEleve(eleveId)
      .pipe(
        map(
          (listeObjectifEleve: ObjectifEleve[]) =>
            listeObjectifEleve.find((objectifEleve: ObjectifEleve) => { objectifEleve.objectifId === objectifId }) || null
        )
      );
  }

  public updateCache() {
    this.updateCache$.next();
  }
}
