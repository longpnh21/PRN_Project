using FluentValidation;
using System;
using UniClub.Domain.Common;
using UniClub.Dtos.Update;

namespace UniClub.Commands.Update.Validators
{
    public class UpdateClubPeriodCommandValidator : UniClubAbstractValidator<UpdateClubPeriodDto>
    {
        public UpdateClubPeriodCommandValidator()
        {
            RuleFor(c => c.ClubId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0);

            RuleFor(c => c.StartDate)
                .NotNull().WithMessage("{PropertyName} is not valid date")
                .GreaterThan(default(DateTime)).WithMessage("{PropertyName} is not valid date");

            RuleFor(c => c.EndDate)
            .NotNull().WithMessage("{PropertyName} is not valid date")
            .GreaterThan(c => c.StartDate).WithMessage("{PropertyName} is not valid date");

            RuleFor(c => c.Status)
                .IsInEnum().WithMessage("{PropertyName} is invalid");
        }
    }
}
