using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Queries.GetById.Specifications;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetById.Handlers
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdDto, PostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<PostDto> Handle(GetPostByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PostDto>(await _postRepository.GetByIdAsync(cancellationToken, new GetPostByIdQuerySpecification(request)));
        }
    }
}
