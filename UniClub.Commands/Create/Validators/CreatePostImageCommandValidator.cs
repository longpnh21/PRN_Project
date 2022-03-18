using FluentValidation;
using UniClub.Domain.Common;
using UniClub.Dtos.Create;

namespace UniClub.Commands.Create.Validators
{
    public class CreatePostImageCommandValidator : UniClubAbstractValidator<CreatePostImageDto>
    {
        public CreatePostImageCommandValidator()
        {
            RuleFor(e => e.PostId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");
        }
    }
}
