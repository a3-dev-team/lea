using System.ComponentModel.DataAnnotations;
using A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles;

namespace A3.Lea.Cycle1.WebApi.Core.Classes.Modeles
{
    public class Classe
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int EcoleId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nom { get; set; } = string.Empty;

        public List<Eleve> Eleves { get; set; } = new List<Eleve>();
    }
}
