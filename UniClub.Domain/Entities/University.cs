using System;
using System.Collections.Generic;
using UniClub.Domain.Common;

#nullable disable

namespace UniClub.Domain.Entities
{
    public partial class University : AuditableEntity<int>
    {
        public University()
        {
            Clubs = new HashSet<Club>();
            Departments = new HashSet<Department>();
        }

        public string UniName { get; set; }
        public string UniAddress { get; set; }
        public string UniPhone { get; set; }
        public string LogoUrl { get; set; }
        public string Slogan { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Website { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
