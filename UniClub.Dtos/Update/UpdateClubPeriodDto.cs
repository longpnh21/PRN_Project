using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Update
{
    public class UpdateClubPeriodDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public int ClubId { get; set; }
        public ClubPeriodStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPresent
        {
            get
            {
                return StartDate.Date <= DateTime.UtcNow.AddDays(1).Date && EndDate.Date >= DateTime.UtcNow.AddDays(-1).Date;
            }
        }
    }
}
