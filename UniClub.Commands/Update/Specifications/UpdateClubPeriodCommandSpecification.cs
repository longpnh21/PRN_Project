using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Specifications;

namespace UniClub.Commands.Update.Specifications
{
    public class UpdateClubPeriodCommandSpecification : BaseSpecification<ClubPeriod>
    {
        public UpdateClubPeriodCommandSpecification(UpdateClubPeriodDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}
