using VMT.CineHub.Domain.Primitives;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Domain.Entities;
public class MovieImage : Entity
{
    public string MovieImageId { get; set; }
    public string Url { get; set; }
    public string MovieId { get; set; }

    private MovieImage
    (
        string url,
        string movieId
    )
    {
        MovieImageId = GenerateIdentifier(DomainPrefixes.movieImage);
        Url = url;
        MovieId = movieId;
    }

    public static MovieImage Create
    (
        string url,
        string movieId
    )
    => new(url, movieId);
}