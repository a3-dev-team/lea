using A3.Lea.Cycle1.WebApi.Core.Commun;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles
{
    public class IdentiteEleve
    {
        public int Id { get; set; }

        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public Sexe Sexe { get; set; }

        public Niveau Niveau { get; set; }

        public int? ClasseId { get; set; }
        public Classe? Classe { get; set; }

        public IdentiteEleve(int id, string nom, string prenom, Sexe sexe, Niveau niveau, object? photo)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Sexe = sexe;
            this.Niveau = niveau;
            this.Photo = photo;
        }

        public bool EstUnGarcon()
        {
            return this.Sexe.Equals(Sexe.Masculin);
        }
    }
}
