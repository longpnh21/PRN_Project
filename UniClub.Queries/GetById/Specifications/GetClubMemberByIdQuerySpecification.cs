using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Specifications;

namespace UniClub.Queries.GetById.Specifications
{
    public class GetClubMemberByIdQuerySpecification : BaseSpecification<MemberRole>
    {
        public GetClubMemberByIdQuerySpecification(GetClubMemberByIdDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.ClubPeriodId == dto.GetClubPeriodId() && e.MemberId.Equals(dto.MemberId));
        }
    }
}
