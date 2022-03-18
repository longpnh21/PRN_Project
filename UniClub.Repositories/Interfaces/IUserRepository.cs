using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Specifications.Interfaces;

namespace UniClub.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(Person entity, CancellationToken cancellationToken);
        Task<int> DeleteAsync(Person entity, CancellationToken cancellationToken);
        Task<Person> GetByIdAsync(CancellationToken cancellationToken, ISpecification<Person> specification);
        Task<(List<Person> Items, int Count)> GetListAsync(CancellationToken cancellationToken, ISpecification<Person> specification = null);
        Task<int> HardDeleteAsync(Person entity, CancellationToken cancellationToken);
        Task<int> UpdateAsync(Person entity, Person updatedEntity, CancellationToken cancellationToken);
    }
}