import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, shareReplay, switchMap } from 'rxjs';
import { ObjectifEleve } from '../models/objectif-eleve.model';
import { ObjectifEleveService } from '../services/objectif-eleve.service';

@Injectable({
  providedIn: 'root'
})
export class ObjectifEleveCache {

  private updateCache$: BehaviorSubject<void> = new BehaviorSubject<void>(undefined);
  private cache: Map<string, Observable<ObjectifEleve>> = new Map<string, Observable<ObjectifEleve>>();

  // public ojbectifsEleve$ = this.updateCache$
  //   .pipe(
  //     // On attend pas que la valeur précédente émise par updateCache$ soit retournée pour déclenchée la suivante, 
  //     // et on écoute pas le retour de la précédente
  //     switchMap(() => { return this.objectifEleveService.chargerObjectifEleve$() }),
  //     shareReplay(1)
  //   );

  constructor(private readonly objectifEleveService: ObjectifEleveService) { }


  public chargerObjectifEleve(eleveId: number, objectifId: number) {
    let cache$ = this.cache.get(this.getCacheKey(eleveId, objectifId));
    if (!cache$) {
      cache$ = this.updateCache$
        .pipe(
          // On attend pas que la valeur précédente émise par updateCache$ soit retournée pour déclenchée la suivante, 
          // et on écoute pas le retour de la précédente
          switchMap(() => { return this.objectifEleveService.chargerObjectifEleve(eleveId, objectifId) }),
          shareReplay(1)
        );
    }
    return cache$;
  }

  public updateCache() {
    this.updateCache$.next();
  }

  private getCacheKey(eleveId: number, objectifId: number) {
    return `${eleveId}_${objectifId}`
  }
}
