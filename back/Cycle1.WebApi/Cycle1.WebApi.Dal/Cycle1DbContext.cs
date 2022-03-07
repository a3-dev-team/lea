using Microsoft.EntityFrameworkCore;

namespace A3.Lea.Cycle1.WebApi.Dal
{
    public class Cycle1DbContext : DbContext
    {
        public Cycle1DbContext()
        { }

        public Cycle1DbContext(DbContextOptions<Cycle1DbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


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


            // this.SaveChanges();


            // // test suppression

            // foreach (var classe in this.Set<Classe>().Where(c => c.Id == 2))
            // {
            //     this.Set<Classe>().Remove(classe);
            // }
            // this.SaveChanges();
        }
    }

}