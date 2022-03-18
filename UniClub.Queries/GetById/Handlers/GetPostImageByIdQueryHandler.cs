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
    public class GetPostImageByIdQueryHandler : IRequestHandler<GetPostImageByIdDto, PostImageDto>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;

        public GetPostImageByIdQueryHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }
        public async Task<PostImageDto> Handle(GetPostImageByIdDto request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PostImageDto>(await _postImageRepository.GetByIdAsync(cancellationToken, new GetPostImageByIdQuerySpecification(request)));
        }
    }
}
