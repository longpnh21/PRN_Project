using System.ComponentModel.DataAnnotations.Schema;
using UniClub.Domain.Common.Interfaces;

namespace UniClub.Domain.Common
{
    public abstract class BaseEntity : IEntity, ISoftDelete
    {
        public bool IsDeleted { get; set; }
        [NotMapped]
        public bool IsHardDeleted { get; set; }
    }
}
