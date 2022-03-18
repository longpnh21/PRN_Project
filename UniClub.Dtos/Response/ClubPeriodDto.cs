using System;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Response
{
    public class ClubPeriodDto
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public ClubPeriodStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
