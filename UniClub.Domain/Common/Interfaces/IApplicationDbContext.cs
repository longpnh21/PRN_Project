using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;

namespace UniClub.Domain.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Club> Clubs { get; }
        DbSet<ClubPeriod> ClubPeriods { get; }
        DbSet<Department> Departments { get; }
        DbSet<Event> Events { get; }
        DbSet<EventByClub> EventByClubs { get; }
        DbSet<MemberRole> MemberRoles { get; }
        DbSet<Participant> Participants { get; }
        DbSet<Person> People { get; }
        DbSet<Post> Posts { get; }
        DbSet<PostImage> PostImages { get; }
        DbSet<StudentInTask> StudentInTasks { get; }
        DbSet<ClubTask> ClubTasks { get; }
        DbSet<University> Universities { get; }
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
