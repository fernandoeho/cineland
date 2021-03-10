using FluentValidation;

namespace Cineland.Application.Entities.Movies.Commands.Validators
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(x => x.Plot)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.RuntimeInMinutes)
                .NotEmpty();

            RuleFor(x => x.ReleaseDate)
                .NotEmpty();
        }
    }
}