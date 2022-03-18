using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteClubMemberDto : IRequest<int>
    {
        public DeleteClubMemberDto(int clubPeriodId, string memberId)
        {
            ClubPeriodId = clubPeriodId;
            MemberId = memberId;
        }

        public int ClubPeriodId { get; }
        public string MemberId { get; }
    }
}
