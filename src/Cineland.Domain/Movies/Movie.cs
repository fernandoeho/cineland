using Cineland.SharedKernel;

namespace Cineland.Domain.Movies;

public class Movie : Entity
{
    public Movie(Guid id, string title, string plot, int runtime, DateOnly releaseDate, string genre, Crew crew) 
        : base(id)
    {
        Title = title;
        Plot = plot;
        Runtime = runtime;
        ReleaseDate = releaseDate;
        Genre = genre;
        Crew = crew;
    }

    public string Title { get; private set; }
    public string Plot { get; private set; }
    public int Runtime { get; private set; }
    public DateOnly ReleaseDate { get; private set; }
    public string Genre { get; private set; }
    public Crew Crew { get; private set; }
}