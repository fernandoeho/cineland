using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cineland.Application.Common.Repository;
using Cineland.Domain.Entities.MovieAggregate;

namespace Cineland.Application.Entities.Movies.Repository
{
    public interface IMovieRepository : IRepository
    {
        Task<Movie> GetById(Guid id);
        Task<IEnumerable<Movie>> GetAll();
        void Add(Movie movie);
    }
}