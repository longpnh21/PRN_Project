using FluentValidation;
using UniClub.Domain.Common;
using UniClub.Dtos.Create;

namespace UniClub.Commands.Create.Validators
{
    public class CreateClubTaskCommandValidator : UniClubAbstractValidator<CreateClubTaskDto>
    {
        public CreateClubTaskCommandValidator()
        {
            RuleFor(e => e.EventId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is not valid date")
                .Must(BeAPresentDate).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.EndDate)
                .Must(BeAFutureDate).WithMessage("{PropertyName} is must be a future date")
                .GreaterThan(e => e.StartDate).WithMessage("{PropertyName} must be greater than start date");

            RuleFor(e => e.Status)
                .IsInEnum().WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.TaskName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 100).WithMessage("Length {PropertyName} must between 2 and 100")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256");
        }
    }
}
