using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public class UniversityRepository : CRUDRepository<University>, IUniversityRepository
    {
        public UniversityRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Universities;
        }

        protected override DbSet<University> DbSet { get; }

    }
}
