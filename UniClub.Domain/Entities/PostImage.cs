#nullable disable

using UniClub.Domain.Common;

namespace UniClub.Domain.Entities
{
    public partial class PostImage : AuditableEntity<int>
    {
        public int PostId { get; set; }
        public string ImageUrl { get; set; }

        public virtual Post Post { get; set; }
    }
}
