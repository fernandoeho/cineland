using System;
using System.Threading.Tasks;
using Cineland.Application.Common.Bus;
using Cineland.Application.Common.Messaging.Notifications;
using Cineland.Application.Entities.Movies.Commands;
using Cineland.Application.Entities.Movies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cineland.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ApiController
    {
        private readonly IBus _bus;

        public MoviesController(INotificationHandler<Notification> notificationHandler, IBus bus)
            : base(notificationHandler)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _bus.RequestAsync(new GetMoviesQuery());

            return Response(movies);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var movie = await _bus.RequestAsync(new GetMovieByIdQuery(id));

            return Response(movie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command)
        {
            var result = await _bus.RequestAsync(command);

            return Response();
        }
    }
}