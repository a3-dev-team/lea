using A3.Lea.Cycle1.WebApi.Core.Ecoles.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace A3.Lea.Cycle1.WebApi.Dal.Ecoles
{
    internal class EcoleConfiguration : IEntityTypeConfiguration<Ecole>
    {
        public void Configure(EntityTypeBuilder<Ecole> builder)
        {

        }
    }
}
