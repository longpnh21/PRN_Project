using FluentValidation;
using System;
using UniClub.Application;
using UniClub.Dtos.Create;

namespace UniClub.Commands.Create.Validators
{
    public class CreateUniversityCommandValidator : UniClubAbstractValidator<CreateUniversityDto>
    {
        public CreateUniversityCommandValidator()
        {
            RuleFor(e => e.UniName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256");

            RuleFor(e => e.UniAddress)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256");

            RuleFor(e => e.Website)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256");

            RuleFor(e => e.UniPhone)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 20).WithMessage("Length {PropertyName} must between 2 and 20");

            RuleFor(e => e.ShortName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 10).WithMessage("Length {PropertyName} must between 2 and 10");

            RuleFor(e => e.EstablishedDate)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(default(DateTime));
        }
    }
}
