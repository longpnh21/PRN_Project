using System.Collections.Generic;
using UniClub.Domain.Common;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class Department : AuditableEntity<int>
    {
        public Department()
        {
            People = new HashSet<Person>();
        }

        public int UniId { get; set; }
        public string DepName { get; set; }
        public string ShortName { get; set; }

        public virtual University University { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
