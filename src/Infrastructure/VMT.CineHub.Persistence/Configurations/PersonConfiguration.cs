using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMT.CineHub.Domain.Entities;
using VMT.CineHub.Domain.ValueObjects;

namespace VMT.CineHub.Persistence.Configurations;
internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.PersonId);

        builder.Property(x => x.Dni)
               .HasConversion(x => x.Value, v => Dni.Create(v).Value)
               .HasMaxLength(Dni.MaxLength);

        builder.Property(x => x.Names)
               .HasMaxLength(50);

        builder.Property(x => x.Surnames)
               .HasMaxLength(50);
    }
}