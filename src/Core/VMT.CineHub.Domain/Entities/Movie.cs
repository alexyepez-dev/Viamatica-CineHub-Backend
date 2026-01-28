using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Primitives;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Domain.Entities;
public sealed class Movie : Entity
{
    public string MovieId { get; private set; }
    public string Name { get; private set; }
    public int Duration { get; private set; }
    public MovieStatus Status { get; private set; }
    public List<MovieMovieTheater> MovieTheaters { get; private set; }


    private Movie
    (
        string name,
        int duration
    )
    {
        MovieId = GenerateIdentifier(DomainPrefixes.movie);
        Name = name;
        Duration = duration;
        Status = MovieStatus.NowPlaying;
        MovieTheaters = [];
    }

    public static Movie Create
    (
        string name,
        int duration
    )
    => new(name, duration);

    public void Update
    (
        string name,
        int duration,
        MovieStatus status
    )
    {
        Name = name;
        Duration = duration;
        Status = status;
    }
}