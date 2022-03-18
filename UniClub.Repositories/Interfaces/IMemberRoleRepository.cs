using UniClub.Domain.Entities;

namespace UniClub.Repositories.Interfaces
{
    public interface IMemberRoleRepository : ICRUDRepository<MemberRole>
    {
        //Task<(List<MemberRole> Items, int Count)> GetListAsync(CancellationToken cancellationToken, ISpecification<MemberRole> specification = null);
        //Task<MemberRole> GetByIdAsync(int clubPeriodId, string memberId, CancellationToken cancellationToken, ISpecification<MemberRole> specification = null);
        //Task<int> CreateAsync(MemberRole entity, CancellationToken cancellationToken);
        //Task<int> UpdateAsync(MemberRole entity, CancellationToken cancellationToken);
        //Task<int> DeleteAsync(MemberRole entity, CancellationToken cancellationToken);
    }
}
