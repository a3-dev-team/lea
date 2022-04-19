using System.ComponentModel.DataAnnotations;
namespace A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles
{
    public class Objectif
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Libelle { get; set; } = string.Empty;

        public string? Description { get; set; }

    }
}