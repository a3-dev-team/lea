using System.ComponentModel.DataAnnotations;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Entites
{
    public class Classe
    {
        public int Id { get; set; }

        [Required]
        public string? Nom { get; set; }

        public virtual ICollection<CarteIdentiteEleve>? CarteIdentiteEleves { get; set; }
    }
}