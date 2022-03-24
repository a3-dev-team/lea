import { Component, OnInit } from '@angular/core';
import { AuthenticationManager, IAuthenticatedUser } from '@core-lib';
import { Classe, ClasseService, Professeur, ProfesseurService } from '@cycle-classe-lib';
import { BaseComponent } from '@shared-lib';
import { mergeMap, of, takeUntil, tap } from 'rxjs';
import { slideInAnimation } from './app.animation';
import { ApplicationStore } from './core/application-store/application-store';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [
    slideInAnimation
  ]
})
export class AppComponent extends BaseComponent implements OnInit {

  constructor(
    public readonly authenticationManager: AuthenticationManager,
    private readonly applicationStore: ApplicationStore,
    private professeurService: ProfesseurService,
    private classeService: ClasseService) {
    super();
  }

  override ngOnInit(): void {

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

}
