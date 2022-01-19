using System.ComponentModel.DataAnnotations;
using A3.Lea.Cycle1.WebApi.Core.Commun;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Entites
{
    public class CarteIdentiteEleve
    {
        public int Id { get; set; }

        [Required]
        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public Sexe Sexe { get; set; }

        public Niveau Niveau { get; set; }
        public int? ClasseId { get; set; }
        public Classe? Classe { get; set; }

    }
}
