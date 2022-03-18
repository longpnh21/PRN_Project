using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Update
{
    public class UpdateClubTaskDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public int EventId { get; set; }
        public ClubTaskStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TaskName { get; set; }
    }
}
