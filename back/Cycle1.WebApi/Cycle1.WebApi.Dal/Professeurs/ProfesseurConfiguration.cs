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
            // Le chargement d'un professeur se fera par son eMail (Version 1)
            // Séquence chargement : 
            //  - Chargement User
            //  - Récupération eMail User
            //  - Chargement Professeur correspondant à l'eMail User
            builder.HasIndex(p => new { p.Email }).IsUnique();
        }
    }
}
