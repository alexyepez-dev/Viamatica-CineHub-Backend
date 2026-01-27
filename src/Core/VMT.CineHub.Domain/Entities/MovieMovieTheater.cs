namespace VMT.CineHub.Domain.Entities;
public sealed class MovieMovieTheater
{
    public string MovieId { get; private set; }
    public string MovieTheaterId { get; private set; }
    public DateTime PublicationDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public Movie? Movie { get; set; }
    public MovieTheater? MovieTheater { get; set; }

    private MovieMovieTheater
    (
        string movieId,
        string movieTheaterId,
        DateTime publicationDate,
        DateTime endDate
    )
    {
        MovieId = movieId;
        MovieTheaterId = movieTheaterId;
        PublicationDate = publicationDate;
        EndDate = endDate;
    }

    public static MovieMovieTheater Create
    (
        string movieId,
        string movieTheaterId,
        DateTime publicationDate,
        DateTime endDate
    )
    => new(movieId, movieTheaterId, publicationDate, endDate);
}