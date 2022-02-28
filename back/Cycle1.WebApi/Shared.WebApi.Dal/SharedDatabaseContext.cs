using A3.Shared.WebApi.Core.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace A3.Shared.WebApi.Dal
{

    public class SharedDatabaseContext : DbContext
    {
        // Documentation :
        // https://docs.microsoft.com/fr-fr/ef/core/modeling/

        public SharedDatabaseContext()
        { }

        public SharedDatabaseContext(DbContextOptions<SharedDatabaseContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());

            // Il est possible d’appliquer l’ensemble de la configuration spécifiée dans les types qui implémentent IEntityTypeConfiguration dans un assembly donné.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SharedDatabaseContext).Assembly);

            // modelBuilder.Entity<Eleve>(entity =>
            // {
            //     // La suppression d'un classe n'entraine pas la suppression des élèves associés.
            //     entity.HasOne(e => e.Classe)
            //     .WithMany(e => e.Eleves)
            //     .OnDelete(DeleteBehavior.SetNull);
            // });

        }

        public void AjouterDonnees()
        {
            User user = new User()
            {
                Email = "lea@a3.fr",
                Password = "10000.mY0XS4oKB/c8UWyZvskgUw==.Xd08mpEMVBVypL1QEE+eMyjXnn3DLEwEKoOaq48sIVI="
            };
            this.Set<User>().Add(user);
            // var classe1 = new Classe()
            // {
            //     Id = 1,
            //     Nom = "Classe1"
            // };
            // this.Set<Classe>().Add(classe1);

            // var classe2 = new Classe()
            // {
            //     Id = 2,
            //     Nom = "Classe2"
            // };
            // this.Set<Classe>().Add(classe2);


            // this.Set<Eleve>().Add(new Eleve()
            // {
            //     Nom = "GALLAIS",
            //     Prenom = "Jonathan",
            //     ClasseId = classe1.Id
            // });
            // this.Set<Eleve>().Add(new Eleve()
            // {
            //     Nom = "DOLET",
            //     Prenom = "Bertrand",
            //     ClasseId = classe1.Id
            // });
            // this.Set<Eleve>().Add(new Eleve()
            // {
            //     Nom = "DERUCHE",
            //     Prenom = "Thomas",
            //     ClasseId = classe2.Id
            // });


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