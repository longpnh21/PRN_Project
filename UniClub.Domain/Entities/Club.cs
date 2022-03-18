using System;
using System.Collections.Generic;
using UniClub.Domain.Common;


#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class Club : AuditableEntity<int>
    {

        public Club()
        {
            ClubPeriods = new HashSet<ClubPeriod>();
            EventByClubs = new HashSet<EventByClub>();
        }
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int UniId { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Slogan { get; set; }
        public int MemberCount { get; set; }


        public virtual University Uni { get; set; }
        public virtual ICollection<ClubPeriod> ClubPeriods { get; set; }
        public virtual ICollection<EventByClub> EventByClubs { get; set; }
    }
}
