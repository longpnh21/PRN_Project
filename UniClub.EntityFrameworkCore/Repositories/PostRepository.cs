using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public class PostRepository : CRUDRepository<Post>, IPostRepository
    {
        public PostRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.Posts;
        }

        protected override DbSet<Post> DbSet { get; }

    }
}
