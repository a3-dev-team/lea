using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;
using Microsoft.EntityFrameworkCore;

namespace A3.Lea.Cycle1.WebApi.MySql
{

    public class DatabaseContext : DbContext
    {

        public DatabaseContext()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CarteIdentiteEleve>(entity =>
            {
                // La suppression d'un classe n'entraine pas la suppression des élèves associés.
                entity.HasOne(c => c.Classe)
                .WithMany(c => c.CarteIdentiteEleves)
                .OnDelete(DeleteBehavior.SetNull);
            });

        }

        public void AjouterDonnees()
        {
            var classe1 = new Classe()
            {
                Id = 1,
                Nom = "Classe1"
            };
            this.Set<Classe>().Add(classe1);

            var classe2 = new Classe()
            {
                Id = 2,
                Nom = "Classe2"
            };
            this.Set<Classe>().Add(classe2);


            this.Set<CarteIdentiteEleve>().Add(new CarteIdentiteEleve()
            {
                Nom = "GALLAIS",
                Prenom = "Jonathan",
                ClasseId = classe1.Id
            });
            this.Set<CarteIdentiteEleve>().Add(new CarteIdentiteEleve()
            {
                Nom = "DOLET",
                Prenom = "Bertrand",
                ClasseId = classe1.Id
            });
            this.Set<CarteIdentiteEleve>().Add(new CarteIdentiteEleve()
            {
                Nom = "DERUCHE",
                Prenom = "Thomas",
                ClasseId = classe2.Id
            });


            this.SaveChanges();


            // test suppression

            foreach (var classe in this.Set<Classe>().Where(c => c.Id == 2))
            {
                this.Set<Classe>().Remove(classe);
            }
            this.SaveChanges();
        }
    }

}