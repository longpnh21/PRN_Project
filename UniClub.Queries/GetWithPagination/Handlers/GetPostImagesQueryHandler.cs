using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Queries.GetWithPagination.Specifications;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetWithPagination.Handlers
{
    public class GetPostImagesQueryHandler : IRequestHandler<GetPostImagesDto, List<PostImageDto>>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;

        public GetPostImagesQueryHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<List<PostImageDto>> Handle(GetPostImagesDto request, CancellationToken cancellationToken)
        {
            var result = await _postImageRepository.GetListAsync(cancellationToken, new GetPostImagesSpecification(request));
            return new List<PostImageDto>(result.Items.Select(e => _mapper.Map<PostImageDto>(e))).ToList();
        }
    }
}
