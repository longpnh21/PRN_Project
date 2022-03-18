using System;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Response
{
    public class EventDto
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int Point { get; set; }
        public int MaxParticipants { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public EventStatus Status { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
