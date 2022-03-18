using MediatR;
using System;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Create
{
    public class CreateClubPeriodDto : IRequest<int>
    {
        public int ClubId { get; set; }
        public ClubPeriodStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
