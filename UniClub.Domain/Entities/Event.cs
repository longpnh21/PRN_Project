using System;
using System.Collections.Generic;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class Event : AuditableEntity<int>
    {
        public Event()
        {
            EventByClubs = new HashSet<EventByClub>();
            Participants = new HashSet<Participant>();
            Tasks = new HashSet<ClubTask>();
        }

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

        public virtual ICollection<EventByClub> EventByClubs { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<ClubTask> Tasks { get; set; }
    }
}
