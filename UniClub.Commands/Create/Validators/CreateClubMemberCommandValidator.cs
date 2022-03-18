using FluentValidation;
using UniClub.Application;
using UniClub.Dtos.Create;

namespace UniClub.Commands.Create.Validators
{
    public class CreateClubMemberCommandValidator : UniClubAbstractValidator<CreateClubMemberDto>
    {
        public CreateClubMemberCommandValidator()
        {
            RuleFor(e => e.MemberId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256");

            RuleFor(e => e.ClubRoleId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.Status)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .IsInEnum();

            RuleFor(e => e.StartDate)
                .NotNull().WithMessage("{PropertyName} is not empty")
                .Must(BeAPresentDate).WithMessage("{PropertyName} must be present day");
        }
    }
}
