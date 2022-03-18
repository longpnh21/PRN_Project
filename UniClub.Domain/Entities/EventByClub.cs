#nullable disable

using UniClub.Domain.Common;

namespace UniClub.Domain.Entities
{
    public partial class EventByClub : BaseEntity
    {
        public int ClubId { get; set; }
        public int EventId { get; set; }
        public bool IsHost { get; set; }

        public virtual Club Club { get; set; }
        public virtual Event Event { get; set; }
    }
}
