using System;
using Cineland.Domain.Common;

namespace Cineland.Domain.Entities.MovieAggregate
{
    public class Movie : Entity, IAggregateRoot
    {
        public Movie(Guid id, string title, string plot, int runtimeInMinutes, DateTime releaseDate)
        {
            Id = id;
            Title = title;
            Plot = plot;
            RuntimeInMinutes = runtimeInMinutes;
            ReleaseDate = releaseDate;
        }

        public string Title { get; private set; }
        public string Plot { get; private set; }
        public int RuntimeInMinutes { get; private set; }
        public DateTime ReleaseDate { get; private set; }
    }
}