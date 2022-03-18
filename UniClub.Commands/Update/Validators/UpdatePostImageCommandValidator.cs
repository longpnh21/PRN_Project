using FluentValidation;
using UniClub.Domain.Common;
using UniClub.Dtos.Update;

namespace UniClub.Commands.Update.Validators
{
    public class UpdatePostImageCommandValidator : UniClubAbstractValidator<UpdatePostImageDto>
    {
        public UpdatePostImageCommandValidator()
        {
            RuleFor(e => e.PostId)
               .NotEmpty().WithMessage("{PropertyName} is not empty")
               .GreaterThan(0).WithMessage("{PropertyName} is invalid");
        }
    }
}
