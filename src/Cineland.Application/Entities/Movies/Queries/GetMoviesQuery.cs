using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cineland.Application.Common.Messaging;
using Cineland.Application.Entities.Movies.Repository;
using Cineland.Domain.Entities.MovieAggregate;
using MediatR;

namespace Cineland.Application.Entities.Movies.Queries
{
    public class GetMoviesQuery : Query<IEnumerable<Movie>>
    { }

    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.GetAll();
        }
    }
}