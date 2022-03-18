using MediatR;

namespace UniClub.Dtos.Create
{
    public class CreateClubRoleDto : IRequest<int>
    {
        public int ClubId { get; set; }
        public string Role { get; set; }
        public int? ReportToRoleId { get; set; }
        public int ClubPeriodId { get; set; }
    }
}
