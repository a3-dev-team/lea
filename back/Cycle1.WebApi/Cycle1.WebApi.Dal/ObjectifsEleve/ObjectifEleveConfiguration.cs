using A3.Lea.Cycle1.WebApi.Core.Objectifs.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace A3.Lea.Cycle1.WebApi.Dal.ObjectifEleves
{
    internal class ObjectifEleveConfiguration : IEntityTypeConfiguration<ObjectifEleve>
    {
        public void Configure(EntityTypeBuilder<ObjectifEleve> builder)
        {
            builder.HasKey(objectifEleve => new { objectifEleve.EleveId, objectifEleve.ObjectifId });

            // builder.HasOne(objectifEleve => objectifEleve.Objectif)
            // .WithMany(objectif => objectif.ListeObjectifEleve)
            // .HasForeignKey(objectifEleve => objectifEleve.ObjectifId)
            // .OnDelete(DeleteBehavior.Cascade);

            // builder.HasOne(objectifEleve => objectifEleve.Eleve)
            // .WithMany(eleve => eleve.ListeObjectifEleve)
            // .HasForeignKey(objectifEleve => objectifEleve.EleveId)
            // .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
