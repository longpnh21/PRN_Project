using System.Collections.Generic;
using UniClub.Domain.Common;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class ClubRole : AuditableEntity<int>
    {
        public ClubRole()
        {
            InverseReportToRole = new HashSet<ClubRole>();
            MemberRoles = new HashSet<MemberRole>();
        }

        public string Role { get; set; }
        public int? ReportToRoleId { get; set; }


        public virtual ClubRole ReportToRole { get; set; }
        public virtual ICollection<ClubRole> InverseReportToRole { get; set; }
        public virtual ICollection<MemberRole> MemberRoles { get; set; }
    }
}
