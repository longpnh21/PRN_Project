using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Services.Interfaces;

#nullable disable

namespace UniClub.EntityFrameworkCore
{
    public partial class UniClubContext : IdentityDbContext<Person>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public UniClubContext(
            DbContextOptions<UniClubContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Club> Clubs => Set<Club>();
        public DbSet<ClubPeriod> ClubPeriods => Set<ClubPeriod>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<EventByClub> EventByClubs => Set<EventByClub>();
        public DbSet<MemberRole> MemberRoles => Set<MemberRole>();
        public DbSet<Participant> Participants => Set<Participant>();
        public DbSet<Person> People => Set<Person>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<PostImage> PostImages => Set<PostImage>();
        public DbSet<StudentInTask> StudentInTasks => Set<StudentInTask>();
        public DbSet<ClubTask> ClubTasks => Set<ClubTask>();
        public DbSet<University> Universities => Set<University>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Person>()
                .Property(p => p.Address)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IMayHaveCreator>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<IHasCreationTime>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationTime = _dateTime.Now;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<IMayHaveModifier>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<IHasModificationTime>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.ModificationTime = _dateTime.Now;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<ISoftDelete>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        if (!entry.Entity.IsHardDeleted)
                        {
                            entry.State = EntityState.Modified;
                            entry.Entity.IsDeleted = true;
                        }
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

    }
}
