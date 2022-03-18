using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public class EventRepository : CRUDRepository<Event>, IEventRepository
    {
        public EventRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Events;
        }

        protected override DbSet<Event> DbSet { get; }
    }
}
