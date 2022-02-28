using System.ComponentModel.DataAnnotations;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles
{
    public class Classe
    {
        public int Id { get; init; }

        [Required]
        public string? Nom { get; init; }

        public virtual ICollection<Eleve>? Eleves { get; init; }
    }
}