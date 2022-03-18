using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Specifications;

namespace UniClub.Queries.GetById.Specifications
{
    public class GetClubPeriodByIdQuerySpecification : BaseSpecification<ClubPeriod>
    {
        public GetClubPeriodByIdQuerySpecification(GetClubPeriodByIdDto query) : base()
        {
            SetFilterCondition(e => !e.IsDeleted);
        }
    }
}
