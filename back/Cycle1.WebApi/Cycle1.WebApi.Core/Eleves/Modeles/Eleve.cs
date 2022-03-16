﻿using System.ComponentModel.DataAnnotations;
using A3.Lea.Cycle1.WebApi.Core.Commun;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles
{
    public class Eleve
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int EcoleId { get; set; }

        [Required]
        public int ClasseId { get; set; }

        [Required]
        public Niveau Niveau { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nom { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        public DateTime? DateNaissance { get; set; }

        [Required]
        public Sexe Sexe { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Emails { get; set; } = string.Empty;
    }
}
