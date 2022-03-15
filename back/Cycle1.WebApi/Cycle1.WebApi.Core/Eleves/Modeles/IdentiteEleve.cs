using System.ComponentModel.DataAnnotations;
using A3.Lea.Cycle1.WebApi.Core.Commun;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles
{
    public class IdentiteEleve
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nom { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        public Sexe Sexe { get; set; }

        public DateTime? DateNaissance { get; set; }

        public bool EstUnGarcon()
        {
            return this.Sexe.Equals(Sexe.Masculin);
        }
    }
}
