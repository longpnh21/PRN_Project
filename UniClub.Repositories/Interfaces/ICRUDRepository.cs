using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Specifications.Interfaces;

namespace UniClub.Repositories.Interfaces
{
    public interface ICRUDRepository<T> where T : BaseEntity
    {
        Task<int> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<int> DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(CancellationToken cancellationToken, ISpecification<T> specification);
        Task<(List<T> Items, int Count)> GetListAsync(CancellationToken cancellationToken, ISpecification<T> specification = null);
        Task<int> HardDeleteAsync(T entity, CancellationToken cancellationToken);
        Task<int> UpdateAsync(T entity, T updatedEntity, CancellationToken cancellationToken);
        Task<int> RecoverAsync(T entity, CancellationToken cancellationToken);
    }
}
