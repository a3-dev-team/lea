using A3.Lea.Cycle1.WebApi.Core.Eleves.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace A3.Lea.Cycle1.WebApi.Dal.Eleves
{
    internal class EleveConfiguration : IEntityTypeConfiguration<Eleve>
    {
        public void Configure(EntityTypeBuilder<Eleve> builder)
        {
            builder.HasIndex(e => new { e.ClasseId, e.Id }).IsUnique();

        }
    }
}
