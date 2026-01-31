using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Primitives;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Domain.Entities;
public sealed class MovieTheater : Entity
{
    public string MovieTheaterId { get; private set; }
    public string Name { get; private set; }
    public MovieTheaterStatus Status { get; private set; }
    public List<MovieMovieTheater> Movies { get; private set; }

    private MovieTheater
    (
        string name
    )
    {
        MovieTheaterId = GenerateIdentifier(DomainPrefixes.movieTheater);
        Name = name;
        Status = MovieTheaterStatus.Available;
        Movies = [];
    }

    public static MovieTheater Create
    (
        string name
    )
    => new(name);

    public void Update
    (
        string name
    )
    => Name = name;

    public void ChangeStatus(MovieTheaterStatus status) => Status = status;
}