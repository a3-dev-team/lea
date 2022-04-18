using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace A3.Lea.Cycle1.WebApi.Dal.Objectifs
{
    internal class ObjectifConfiguration : IEntityTypeConfiguration<Objectif>
    {
        public void Configure(EntityTypeBuilder<Objectif> builder)
        {
            // builder.HasKey(e => new { e.ClasseId, e.Id }).IsUnique();
        }
    }
}
