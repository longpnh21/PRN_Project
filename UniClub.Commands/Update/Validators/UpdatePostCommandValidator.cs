using FluentValidation;
using UniClub.Application;
using UniClub.Dtos.Update;

namespace UniClub.Commands.Update.Validators
{
    public class UpdatePostCommandValidator : UniClubAbstractValidator<UpdatePostDto>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(e => e.PersonId)
                 .NotNull().WithMessage("{PropertyName} is not empty")
                 .Length(2, 300).WithMessage("Length {PropertyName} must between 2 and 300");

            RuleFor(e => e.Title)
                .NotNull().WithMessage("{PropertyName} is not empty")
                .Length(2, 100).WithMessage("Length {PropertyName} must between 2 and 100");

            RuleFor(e => e.Status)
                .IsInEnum();

            RuleFor(e => e.ShortDescription)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 1000).WithMessage("Length {PropertyName} must between 2 and 1000")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.Content)
                .NotNull().WithMessage("{PropertyName} is invalid")
                .Length(2, 2000).WithMessage("Length {PropertyName} must between 2 and 2000");

            RuleFor(e => e.EventId)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} is invalid");
        }
    }
}
