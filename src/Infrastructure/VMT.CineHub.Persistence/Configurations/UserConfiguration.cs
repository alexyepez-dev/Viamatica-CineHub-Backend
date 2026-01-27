using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.ValueObjects;

namespace VMT.CineHub.Persistence.Configurations;
internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);

        builder.Property(x => x.Username)
               .HasMaxLength(50);

        builder.Property(x => x.Email)
               .HasConversion(x => x.Value, v => Email.Create(v).Value)
               .HasMaxLength(Email.MaxLength);

        builder.Property(x => x.Password)
               .HasMaxLength(100);

        builder.HasOne(x => x.Person)
               .WithOne()
               .HasForeignKey<User>(x => x.PersonId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}