using FluentValidation;
using UniClub.Domain.Common;
using UniClub.Dtos.Create;

namespace UniClub.Commands.Create.Validators
{
    public class CreateDepartmentCommandValidator : UniClubAbstractValidator<CreateDepartmentDto>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(e => e.UniId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.ShortName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 10).WithMessage("Length {PropertyName} must between 2 and 10")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.DepName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");
        }
    }
}
