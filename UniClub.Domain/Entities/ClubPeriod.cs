using System;
using System.Collections.Generic;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class ClubPeriod : AuditableEntity<int>
    {
        public ClubPeriod()
        {
            MemberRoles = new HashSet<MemberRole>();
        }

        public int ClubId { get; set; }
        public ClubPeriodStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPresent { get; set; }

        public virtual Club Club { get; set; }
        public virtual ICollection<MemberRole> MemberRoles { get; set; }
    }
}
