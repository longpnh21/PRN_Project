using System;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Response
{
    public class ClubTaskDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public ClubTaskStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TaskName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
