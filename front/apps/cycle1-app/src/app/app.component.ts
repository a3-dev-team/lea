import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthenticationManager, IAuthenticatedUser } from '@core-lib';
import { Classe, ClasseService, Professeur, ProfesseurService } from '@cycle-classe-lib';
import { BaseComponent } from '@shared-lib';
import { mergeMap, of, takeUntil, tap } from 'rxjs';
import * as packageInfo from '../../../../package.json';
import { routeAnimations } from './app.animation';
import { ApplicationStore } from './core/application-store/application-store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [
    routeAnimations
  ]
})
export class AppComponent extends BaseComponent implements OnInit {

  // Expose package.json, pas une bonne pratique, risque sécurité
  // https://stackoverflow.com/questions/64993118/error-should-not-import-the-named-export-version-imported-as-version
  public packageInfo = packageInfo
  public version: string = this.packageInfo.version;

  constructor(
    public readonly authenticationManager: AuthenticationManager,
    private readonly applicationStore: ApplicationStore,
    private professeurService: ProfesseurService,
    private classeService: ClasseService) {
    super();
  }

  public override ngOnInit(): void {

    super.ngOnInit();

    // Pour chaque utilisateur authentifié
    this.authenticationManager.authenticatedUserState$
      .pipe(
        takeUntil(this.destroyAction$),
        mergeMap((authenticatedUser: IAuthenticatedUser | null) => {
          if (authenticatedUser) {
            // Chargement du professeur correspond à l'utilisateur authentifié
            return this.professeurService.chargerProfesseurParEmail(authenticatedUser.email)
              .pipe(
                tap((professeur: Professeur) => {
                  // Mise à jour du cache applicatif avec le professeur (utilisateur authentifié)
                  this.applicationStore.MettreAJourProfesseur(professeur);
                }),
                mergeMap((professeur: Professeur) => {
                  // Chargement de la classe du professeur
                  return this.classeService.chargerClasse(professeur.classeId)
                    .pipe(
                      tap((classe: Classe) => {
                        // Mise à jour du cache applicatif avec la classe du professeur
                        this.applicationStore.MettreAJourClasse(classe);
                      })
                    )
                })
              );
          }
          else {
            return of(null);
          }
        }))
      .subscribe();

  }

  public prepareRoute(routerOutlet: RouterOutlet) {
    return routerOutlet &&
      routerOutlet.activatedRouteData &&
      routerOutlet.activatedRouteData['animationState'];
  }

}
