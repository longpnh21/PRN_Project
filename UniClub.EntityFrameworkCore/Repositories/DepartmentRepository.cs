using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public class DepartmentRepository : CRUDRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Departments;
        }

        protected override DbSet<Department> DbSet { get; }

    }
}
