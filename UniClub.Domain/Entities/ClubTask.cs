using System;
using System.Collections.Generic;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class ClubTask : AuditableEntity<int>
    {
        public ClubTask()
        {
            StudentInTasks = new HashSet<StudentInTask>();
        }

        public int EventId { get; set; }
        public ClubTaskStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TaskName { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<StudentInTask> StudentInTasks { get; set; }
    }
}
