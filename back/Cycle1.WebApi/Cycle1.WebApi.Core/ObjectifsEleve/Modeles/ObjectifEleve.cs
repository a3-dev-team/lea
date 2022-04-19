using System.ComponentModel.DataAnnotations;

namespace A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles
{
    public class ObjectifEleve
    {
        [Required]
        public int EleveId { get; set; }

        [Required]
        public int ObjectifId { get; set; }

        public DateTime? DateValidation { get; set; }

        public Guid? PhotoId { get; set; }

        public Objectif? Objectif { get; set; }

    }
}