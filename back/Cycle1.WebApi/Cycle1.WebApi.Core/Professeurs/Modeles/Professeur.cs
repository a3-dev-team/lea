using System.ComponentModel.DataAnnotations;

namespace A3.Lea.Cycle1.WebApi.Core.Professeurs.Modeles
{
    public class Professeur
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int EcoleId { get; set; }

        [Required]
        public int ClasseId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nom { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        public DateTime? DateNaissance { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; } = string.Empty;
    }
}
