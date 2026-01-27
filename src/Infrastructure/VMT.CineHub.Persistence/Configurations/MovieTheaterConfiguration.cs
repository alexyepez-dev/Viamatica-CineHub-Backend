using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMT.CineHub.Domain.Entities;

namespace VMT.CineHub.Persistence.Configurations;
internal sealed class MovieTheaterConfiguration : IEntityTypeConfiguration<MovieTheater>
{
    public void Configure(EntityTypeBuilder<MovieTheater> builder)
    {
        builder.HasKey(x => x.MovieTheaterId);

        builder.Property(x => x.Name)
               .HasMaxLength(100);

        builder.Property(x => x.Status)
               .HasConversion<string>();
    }
}