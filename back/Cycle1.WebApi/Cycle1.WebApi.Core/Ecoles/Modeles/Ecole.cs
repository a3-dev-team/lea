using System.ComponentModel.DataAnnotations;
using A3.Lea.Cycle1.WebApi.Core.Classes.Modeles;
using A3.Lea.Cycle1.WebApi.Core.Commun.Modeles;

namespace A3.Lea.Cycle1.WebApi.Core.Ecoles.Modeles
{
    public class Ecole
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nom { get; set; } = string.Empty;

        public string? EMail { get; set; }

        public string? Telephone { get; set; }

        public Adresse Adresse { get; set; } = new Adresse();

        public List<Classe> Classes { get; set; } = new List<Classe>();
    }
}
