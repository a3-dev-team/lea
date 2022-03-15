using System.ComponentModel.DataAnnotations;
using A3.Lea.Cycle1.WebApi.Core.Commun;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles
{
    public class Eleve
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ClasseId { get; set; }

        [Required]
        public Niveau Niveau { get; set; }

        public string? Emails { get; set; }

        public IdentiteEleve Identite { get; set; } = new IdentiteEleve();
    }
}
