using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMT.CineHub.Domain.Entities;

namespace VMT.CineHub.Persistence.Configurations;
internal sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => x.MovieId);

        builder.Property(x => x.Name)
               .HasMaxLength(200);

        builder.Property(x => x.Duration);

        builder.Property(x => x.Status)
               .HasConversion<string>();
    }
}