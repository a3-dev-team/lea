using A3.Lea.Cycle1.WebApi.Core.Professeurs.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace A3.Lea.Cycle1.WebApi.Dal.Professeurs
{
    internal class ProfesseurConfiguration : IEntityTypeConfiguration<Professeur>
    {
        public void Configure(EntityTypeBuilder<Professeur> builder)
        {
            builder.HasIndex(p => new { p.EcoleId, p.Id }).IsUnique();
            // Le chargement d'un professeur se fera par son email (Version 1)
            // Séquence chargement : 
            //  - Chargement User
            //  - Récupération email User
            //  - Chargement Professeur correspondant à l'email User
            builder.HasIndex(p => new { p.Email }).IsUnique();
        }
    }
}
