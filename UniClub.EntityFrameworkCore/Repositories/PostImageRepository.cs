using Microsoft.EntityFrameworkCore;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;

namespace UniClub.EntityFrameworkCore.Repositories
{
    public class PostImageRepository : CRUDRepository<PostImage>, IPostImageRepository
    {
        public PostImageRepository(IApplicationDbContext context) : base(context)
        {
            DbSet = context.PostImages;
        }

        protected override DbSet<PostImage> DbSet { get; }

    }
}
