using UniClub.Domain.Entities;
using UniClub.Dtos.Recover;
using UniClub.Specifications;

namespace UniClub.Commands.Recover.Specifications
{
    public class RecoverClubMemberCommandSpecification : BaseSpecification<MemberRole>
    {
        public RecoverClubMemberCommandSpecification(RecoverClubMemberDto dto)
        {
            SetFilterCondition(e => e.IsDeleted);

            SetFilterCondition(e => e.ClubPeriodId == dto.GetClubPeriodId() && e.MemberId.Equals(dto.MemberId));
        }
    }
}
