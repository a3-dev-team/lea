using System.ComponentModel.DataAnnotations;

namespace A3.Lea.Cycle1.WebApi.Core.Commun.Modeles
{
    public class Adresse
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Voie { get; set; } = string.Empty;

        public string? Complement { get; set; }

        public string? BoitePostale { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string CodePostal { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Commune { get; set; } = string.Empty;
    }
}
