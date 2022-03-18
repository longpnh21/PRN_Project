using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetClubMemberByIdDto : IRequest<MemberRoleDto>
    {
        public string MemberId { get; set; }
        private int _clubPeriodId;
        public GetClubMemberByIdDto(string memberId)
        {
            MemberId = memberId;
        }

        public int GetClubPeriodId() => _clubPeriodId;
        public void SetClubPeriodId(int clubPeriodId) => _clubPeriodId = clubPeriodId;
    }
}
