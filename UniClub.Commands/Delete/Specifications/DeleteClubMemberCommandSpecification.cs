using UniClub.Domain.Entities;
using UniClub.Dtos.Delete;
using UniClub.Specifications;

namespace UniClub.Commands.Delete.Specifications
{
    public class DeleteClubMemberCommandSpecification : BaseSpecification<MemberRole>
    {
        public DeleteClubMemberCommandSpecification(DeleteClubMemberDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);
            SetFilterCondition(e => e.MemberId.Equals(dto.MemberId) && e.ClubPeriodId == e.ClubPeriodId);
        }
    }
}
