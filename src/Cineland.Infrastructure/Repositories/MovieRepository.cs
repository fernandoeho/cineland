using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cineland.Application.Entities.Movies.Repository;
using Cineland.Domain.Entities.MovieAggregate;

namespace Cineland.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie(Guid.NewGuid(), "The Godfather", "Best movie ever!!!", 180, DateTime.UtcNow)
            };
        }

        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        public Task<IEnumerable<Movie>> GetAll()
        {
            return Task.FromResult(_movies.AsEnumerable());
        }

        public Task<Movie> GetById(Guid id)
        {
            return Task.FromResult(_movies.Where(x => x.Id == id).SingleOrDefault());
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(1);
        }
    }
}