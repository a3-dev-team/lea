using A3.Lea.Cycle1.WebApi.Core.Commun.Modeles;

namespace A3.Lea.Cycle1.WebApi.Core.Ecoles.Modeles
{
    public class Ecole
    {
        public int Id { get; set; }

        public string? Nom { get; set; }

        public string? EMail { get; set; }

        public string? Telephone { get; set; }

        public Adresse? Adresse { get; set; }
    }
}
