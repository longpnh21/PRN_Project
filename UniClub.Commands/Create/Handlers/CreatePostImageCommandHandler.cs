using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreatePostImageDtoQueryHandler : IRequestHandler<CreatePostImageDto, int>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;

        public CreatePostImageDtoQueryHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePostImageDto request, CancellationToken cancellationToken)
        {
            return await _postImageRepository.CreateAsync(_mapper.Map<PostImage>(request), cancellationToken);
        }
    }
}
