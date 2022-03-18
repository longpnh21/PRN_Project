using MediatR;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Update
{
    public class UpdateClubRoleDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string Role { get; set; }
        public int? ReportToRoleId { get; set; }
        public int ClubPeriodId { get; set; }
    }
}
