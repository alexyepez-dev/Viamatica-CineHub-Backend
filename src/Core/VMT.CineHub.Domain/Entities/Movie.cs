using VMT.CineHub.Domain.Enums;
using VMT.CineHub.Domain.Primitives;
using VMT.CineHub.Domain.Shared;

namespace VMT.CineHub.Domain.Entities;
public sealed class Movie : Entity
{
    public string MovieId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Duration { get; private set; }
    public MovieStatus Status { get; private set; }
    public string Slug { get; private set; }
    public List<MovieImage> MovieImages { get; private set; }
    public List<MovieMovieTheater> MovieTheaters { get; private set; }


    private Movie
    (
        string name,
        int duration,
        string description,
        MovieStatus status
    )
    {
        MovieId = GenerateIdentifier(DomainPrefixes.movie);
        Name = name;
        Description = description;
        Duration = duration;
        Status = status;
        Slug = GenerateSlug(name);
        MovieImages = [];
        MovieTheaters = [];
    }

    public static Movie Create
    (
        string name,
        int duration,
        string description,
        MovieStatus status
    )
    => new(name, duration, description, status);

    public void Update
    (
        string name,
        int duration,
        string description,
        MovieStatus status
    )
    {
        Name = name;
        Duration = duration;
        Description = description;
        Status = status;
    }

    public void ChangeStatusToDeleted() => Status = MovieStatus.Deleted;
}