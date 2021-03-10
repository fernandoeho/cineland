using System;
using System.Threading;
using System.Threading.Tasks;
using Cineland.Application.Common.Messaging;
using Cineland.Application.Entities.Movies.Repository;
using Cineland.Domain.Entities.MovieAggregate;
using MediatR;

namespace Cineland.Application.Entities.Movies.Commands
{
    public class CreateMovieCommand : Command
    {
        public CreateMovieCommand(string title, string plot, int runtimeInMinutes, DateTime releaseDate)
        {
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

    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<bool> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie(Guid.NewGuid(), request.Title, request.Plot, request.RuntimeInMinutes, request.ReleaseDate);

            _movieRepository.Add(movie);

            await _movieRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}