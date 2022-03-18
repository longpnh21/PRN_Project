using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Queries.GetWithPagination.Specifications;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetWithPagination.Handlers
{
    public class GetPostsWithPaginationQueryHandler : IRequestHandler<GetPostsWithPaginationDto, PaginatedList<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostsWithPaginationQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PostDto>> Handle(GetPostsWithPaginationDto request, CancellationToken cancellationToken)
        {
            var result = await _postRepository.GetListAsync(cancellationToken, new GetPostsWithPaginationSpecification(request));
            return new PaginatedList<PostDto>(result.Items.Select(e => _mapper.Map<PostDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
