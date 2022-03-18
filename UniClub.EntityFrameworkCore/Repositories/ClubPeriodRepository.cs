using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public class ClubPeriodRepository : CRUDRepository<ClubPeriod>, IClubPeriodRepository
    {
        public ClubPeriodRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.ClubPeriods;
        }

        protected override DbSet<ClubPeriod> DbSet { get; }
    }
}
