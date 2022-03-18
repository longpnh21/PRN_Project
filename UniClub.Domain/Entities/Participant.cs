using System;
using UniClub.Domain.Common;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class Participant : BaseEntity
    {
        public string UserId { get; set; }
        public int EventId { get; set; }
        public bool IsJoined { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckoutDate { get; set; }

        public virtual Event Event { get; set; }
        public virtual Person Person { get; set; }
    }
}
