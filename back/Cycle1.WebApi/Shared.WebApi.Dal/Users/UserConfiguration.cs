using A3.Shared.WebApi.Core.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace A3.Shared.WebApi.Dal.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        // Documentation :
        // https://docs.microsoft.com/fr-fr/ef/core/modeling/

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Id).IsRequired();
        }
    }
}