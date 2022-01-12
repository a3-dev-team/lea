using A3.Lea.Cycle1.WebApi.Core.Eleves.Entites;
using Microsoft.EntityFrameworkCore;

namespace A3.Lea.Cycle1.WebApi.MySql
{

    public class DatabaseContext : DbContext
    {
        // public DbSet<Classe>? Classe { get; set; }

        // public DbSet<Eleve>? Eleve { get; set; }

        // public DbSet<CarteIdentiteEleve>? CarteIdentiteEleve { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Classe>(entity =>
            {
                // entity.HasKey(c => c.Id);
                // entity.Property(e => e.Nom).IsRequired();
            });

            modelBuilder.Entity<CarteIdentiteEleve>(entity =>
            {
                // La suppression d'un classe n'entraine pas la suppression des élèves associés.
                entity.HasOne(c => c.Classe)
                .WithMany(c => c.CarteIdentiteEleves)
                .OnDelete(DeleteBehavior.SetNull);
            });

            // modelBuilder.Entity<Eleve>(entity =>
            // {
            //     entity.HasKey(e => e.Id);
            //     entity.HasOne(e => e.Classe)
            //     .WithMany(c => c.Eleves);
            // });
        }

        public void AjouterDonnees()
        {

            this.Set<Classe>().Add(new Classe()
            {
                Id = 1,
                Nom = "Classe1"
            });
            this.Set<Classe>().Add(new Classe()
            {
                Id = 2,
                Nom = "Classe2"
            });


            this.Set<CarteIdentiteEleve>().Add(new CarteIdentiteEleve()
            {
                Nom = "GALLAIS",
                Prenom = "Jonathan",
                ClasseId = 1
            });
            this.Set<CarteIdentiteEleve>().Add(new CarteIdentiteEleve()
            {
                Nom = "DOLET",
                Prenom = "Bertrand",
                ClasseId = 1
            });
            this.Set<CarteIdentiteEleve>().Add(new CarteIdentiteEleve()
            {
                Nom = "DERUCHE",
                Prenom = "Thomas",
                ClasseId = 2
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