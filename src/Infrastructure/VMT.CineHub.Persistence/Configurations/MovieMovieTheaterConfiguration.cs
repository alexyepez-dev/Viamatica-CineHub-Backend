using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMT.CineHub.Domain.Entities;

namespace VMT.CineHub.Persistence.Configurations;
internal sealed class MovieMovieTheaterConfiguration : IEntityTypeConfiguration<MovieMovieTheater>
{
    public void Configure(EntityTypeBuilder<MovieMovieTheater> builder)
    {
        builder.HasKey
        (
            x => new
            {
                x.MovieId,
                x.MovieTheaterId
            }
        );

        builder.Property(x => x.PublicationDate);

        builder.Property(x => x.EndDate);

        builder.HasOne(x => x.Movie)
               .WithMany(x => x.MovieTheaters)
               .HasForeignKey(x => x.MovieId);

        builder.HasOne(x => x.MovieTheater)
               .WithMany(x => x.Movies)
               .HasForeignKey(x => x.MovieTheaterId);
    }
}