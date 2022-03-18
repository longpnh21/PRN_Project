using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;
namespace UniClub.EntityFrameworkCore.Repositories
{
    public class ClubRoleRepository : CRUDRepository<ClubRole>, IClubRoleRepository
    {
        public ClubRoleRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.ClubRoles;
        }

        protected override DbSet<ClubRole> DbSet { get; }

    }
}
