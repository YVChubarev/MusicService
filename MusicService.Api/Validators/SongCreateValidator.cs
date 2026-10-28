using FluentValidation;
using MusicService.Api.Contracts;

namespace MusicService.Api.Validators
{
    /// <summary>
    /// Валидатор для <see cref="SongCreateDto"/>.
    /// Title.Length [1, 200].
    /// AudioStreamUrl is Uri.
    /// </summary>
    public class SongCreateValidator : AbstractValidator<SongCreateDto>
    {
        /// <inheritdoc cref="SongCreateValidator"/>
        public SongCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title is long.");

            RuleFor(x => x.AudioStreamUrl)
                .NotEmpty().WithMessage("AudioStreamUrl is required.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("AudioStreamUrl must be a valid absolute URL.");
        }
    }
}
