using System;
using System.Threading.Tasks;
using UniClub.Domain.Common;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class StudentInTask : BaseEntity
    {
        public string StudentId { get; set; }
        public int TaskId { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime AssignedTime { get; set; }

        public virtual Person Student { get; set; }
        public virtual ClubTask Task { get; set; }
    }
}
