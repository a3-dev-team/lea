using A3.Lea.Cycle1.WebApi.Core.Classes.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace A3.Lea.Cycle1.WebApi.Dal.Classes
{
    internal class ClasseConfiguration : IEntityTypeConfiguration<Classe>
    {
        public void Configure(EntityTypeBuilder<Classe> builder)
        {
            builder.HasIndex(c => new { c.EcoleId, c.Id }).IsUnique();
        }
    }
}
