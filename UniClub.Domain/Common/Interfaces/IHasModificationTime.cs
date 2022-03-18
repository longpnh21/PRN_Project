using System;

namespace UniClub.Domain.Common.Interfaces
{
    public interface IHasModificationTime
    {
        DateTime ModificationTime { get; set; }
    }
}
