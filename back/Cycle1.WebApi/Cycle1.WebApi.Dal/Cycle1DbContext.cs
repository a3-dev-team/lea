using A3.Lea.Cycle1.WebApi.Core.Classes.Modeles;
using A3.Lea.Cycle1.WebApi.Core.Ecoles.Modeles;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles;
using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using A3.Lea.Cycle1.WebApi.Core.Professeurs.Modeles;
using Microsoft.EntityFrameworkCore;

namespace A3.Lea.Cycle1.WebApi.Dal
{
    public class Cycle1DbContext : DbContext
    {
        public Cycle1DbContext() { }

        public Cycle1DbContext(DbContextOptions<Cycle1DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Il est possible d’appliquer l’ensemble de la configuration spécifiée dans les types qui implémentent IEntityTypeConfiguration dans un assembly donné.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Cycle1DbContext).Assembly);
        }


        public void AjouterDonnees()
        {
            var ecole = new Ecole()
            {
                Id = 1,
                Nom = "Sainte Famille",
                EMail = "bertrand.dolet@gmail.com"
            };
            ecole.Adresse.Id = 1;
            ecole.Adresse.Voie = "8 rue de l'ecole en mousse";
            ecole.Adresse.CodePostal = "80480";
            ecole.Adresse.Commune = "AMIENS";
            this.Set<Ecole>().Add(ecole);


            var professeur = new Professeur()
            {
                Id = 1,
                Nom = "TOURNESOL",
                EcoleId = ecole.Id,
                ClasseId = 1,
                Prenom = "Professeur",
                Email = "lea@a3.fr",
                DateNaissance = new DateTime(1901, 11, 11)
            };

            this.Set<Professeur>().Add(professeur);

            var classe = new Classe()
            {
                Id = 1,
                Nom = "Moyenne Section A",
                EcoleId = ecole.Id,
            };
            this.Set<Classe>().Add(classe);

            Eleve bertrand = new Eleve()
            {
                Id = 1,
                ClasseId = classe.Id,
                Niveau = Core.Commun.Niveau.MoyenneSection
            };
            bertrand.Nom = "DOLET";
            bertrand.Prenom = "Bertrand";
            bertrand.Sexe = Core.Commun.Sexe.Masculin;
            bertrand.DateNaissance = new DateTime(1988, 11, 11);

            this.Set<Eleve>().Add(bertrand);

            Eleve jonathan = new Eleve()
            {
                Id = 2,
                ClasseId = classe.Id,
                Niveau = Core.Commun.Niveau.GrandeSection
            };
            jonathan.Nom = "GALLAIS";
            jonathan.Prenom = "Jonathan";
            jonathan.Sexe = Core.Commun.Sexe.Masculin;
            jonathan.DateNaissance = new DateTime(1979, 07, 27);

            this.Set<Eleve>().Add(jonathan);

            // ************ Objectifs

            Objectif objectif1 = new Objectif()
            {
                Id = 1,
                Libelle = "Objectif1",
                Description = "C'est l'objectif 1"
            };
            this.Set<Objectif>().Add(objectif1);

            Objectif objectif2 = new Objectif()
            {
                Id = 2,
                Libelle = "Objectif2",
                Description = "C'est l'objectif 2"
            };
            this.Set<Objectif>().Add(objectif2);

            // ************ ObjectifsEleve

            ObjectifEleve objectif1EleveJonathan = new ObjectifEleve()
            {
                EleveId = jonathan.Id,
                ObjectifId = objectif1.Id,
                DateValidation = DateTime.Now
            };
            this.Set<ObjectifEleve>().Add(objectif1EleveJonathan);

            // ObjectifEleve objectif2EleveJonathan = new ObjectifEleve()
            // {
            //     EleveId = jonathan.Id,
            //     ObjectifId = objectif2.Id,
            //     DateValidation = DateTime.Now
            // };
            // this.Set<ObjectifEleve>().Add(objectif2EleveJonathan);

            ObjectifEleve objectif1EleveBertrand = new ObjectifEleve()
            {
                EleveId = bertrand.Id,
                ObjectifId = objectif1.Id,
                DateValidation = DateTime.Now
            };
            this.Set<ObjectifEleve>().Add(objectif1EleveBertrand);

            ObjectifEleve objectif2EleveBertrand = new ObjectifEleve()
            {
                EleveId = bertrand.Id,
                ObjectifId = objectif2.Id,
                DateValidation = DateTime.Now
            };
            this.Set<ObjectifEleve>().Add(objectif2EleveBertrand);


            this.SaveChanges();


            // // test suppression

            // foreach (var classe in this.Set<Classe>().Where(c => c.Id == 2))
            // {
            //     this.Set<Classe>().Remove(classe);
            // }
            // this.SaveChanges();
        }
    }

}