using MediatR;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetPostsWithPaginationDto : RequestPaginationQuery<PostProperties?>, IRequest<PaginatedList<PostDto>>
    {
        public override PostProperties? OrderBy { get; set; }
    }
}
