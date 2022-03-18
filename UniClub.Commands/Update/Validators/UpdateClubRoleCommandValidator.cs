using FluentValidation;
using UniClub.Domain.Common;
using UniClub.Dtos.Update;

namespace UniClub.Commands.Update.Validators
{
    public class UpdateClubRoleCommandValidator : UniClubAbstractValidator<UpdateClubRoleDto>
    {
        public UpdateClubRoleCommandValidator()
        {
            RuleFor(c => c.ClubId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(c => c.Role)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 50).WithMessage("Length {PropertyName} must between 2 and 50")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(c => c.ClubPeriodId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");
        }
    }
}
