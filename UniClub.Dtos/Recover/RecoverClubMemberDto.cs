using MediatR;

namespace UniClub.Dtos.Recover
{
    public class RecoverClubMemberDto : IRequest<int>
    {
        public string MemberId { get; set; }
        private int _clubPeriodId;
        public RecoverClubMemberDto(string memberId)
        {
            MemberId = memberId;
        }

        public int GetClubPeriodId() => _clubPeriodId;
        public void SetClubPeriodId(int clubPeriodId) => _clubPeriodId = clubPeriodId;
    }
}
