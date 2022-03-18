using FluentValidation;
using UniClub.Domain.Common;
using UniClub.Dtos.Update;

namespace UniClub.Commands.Update.Validators
{
    public class UpdateEventCommandValidator : UniClubAbstractValidator<UpdateEventDto>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(e => e.StartDate)
                .NotNull().WithMessage("{PropertyName} is not null")
                .Must(BeAFutureDate).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.EndDate)
                .NotNull().WithMessage("{PropertyName} is not null")
                .Must(BeAFutureDate).WithMessage("{PropertyName} is invalid")
                .GreaterThan(e => e.StartDate).WithMessage("{PropertyName} must be greater than start date");

            RuleFor(e => e.MaxParticipants)
                .NotNull().WithMessage("{PropertyName} is invalid")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.Status)
                .IsInEnum();

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 50).WithMessage("Length {PropertyName} must between 2 and 256")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.MaxParticipants)
                .NotNull().WithMessage("{PropertyName} is invalid")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(e => e.Point)
                .NotNull().WithMessage("{PropertyName} is invalid")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} is invalid");
        }
    }
}
