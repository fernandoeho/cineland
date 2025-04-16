namespace Cineland.Domain.Movies;

public record Crew
{
    public required string Director { get; init; }
    public required string Cast { get; init; }
}