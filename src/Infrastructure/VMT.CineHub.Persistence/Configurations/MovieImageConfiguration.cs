using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMT.CineHub.Domain.Entities;

namespace VMT.CineHub.Persistence.Configurations;
internal sealed class MovieImageConfiguration : IEntityTypeConfiguration<MovieImage>
{
    public void Configure(EntityTypeBuilder<MovieImage> builder)
    {
        builder.HasKey(x => x.MovieImageId);

        builder.Property(x => x.Url)
               .HasMaxLength(5000);

        builder.HasOne<Movie>()
               .WithMany(x => x.MovieImages)
               .HasForeignKey(x => x.MovieId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}