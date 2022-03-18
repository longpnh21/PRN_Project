namespace UniClub.Domain.Common.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        bool IsHardDeleted { get; set; }
    }
}
