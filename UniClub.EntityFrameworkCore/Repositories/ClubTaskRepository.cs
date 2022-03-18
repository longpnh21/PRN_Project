using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public class ClubTaskRepository : CRUDRepository<ClubTask>, IClubTaskRepository
    {
        public ClubTaskRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.ClubTasks;
        }

        protected override DbSet<ClubTask> DbSet { get; }

    }
}
