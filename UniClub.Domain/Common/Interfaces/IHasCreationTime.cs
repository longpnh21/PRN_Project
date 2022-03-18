using System;

namespace UniClub.Domain.Common.Interfaces
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}
