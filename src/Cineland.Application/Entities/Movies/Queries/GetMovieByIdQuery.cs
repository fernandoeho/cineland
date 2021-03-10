using System;
using System.Threading;
using System.Threading.Tasks;
using Cineland.Application.Common.Messaging;
using Cineland.Application.Entities.Movies.Repository;
using Cineland.Domain.Entities.MovieAggregate;
using MediatR;

namespace Cineland.Application.Entities.Movies.Queries
{
    public class GetMovieByIdQuery : Query<Movie>
    {
        public GetMovieByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }

    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMovieByIdQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.GetById(request.Id);
        }
    }
}