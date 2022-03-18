using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public class MemberRoleRepository : CRUDRepository<MemberRole>, IMemberRoleRepository
    {

        public MemberRoleRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.MemberRoles;
        }

        protected override DbSet<MemberRole> DbSet { get; }

        protected override void UpdateEntityWithInDatabase(MemberRole inDatabase, MemberRole entity)
        {
            foreach (var inDatabaseProperty in inDatabase.GetType().GetProperties())
            {
                if (!inDatabaseProperty.Name.Contains("MemberId") || !inDatabaseProperty.Name.Contains("ClubPeriodId"))
                {
                    var entityValue = entity.GetType().GetProperty(inDatabaseProperty.Name).GetValue(entity);
                    {
                        if (entityValue != null && entityValue != default)
                        {
                            entity.GetType().GetProperty(inDatabaseProperty.Name).SetValue(inDatabase, entityValue);
                        }
                    }
                }
            }
        }
    }
}
