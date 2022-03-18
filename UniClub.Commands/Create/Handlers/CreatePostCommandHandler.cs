using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostDto, int>
    {
        private readonly IPostRepository _postReposiotry;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postReposiotry = postRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePostDto request, CancellationToken cancellationToken)
        {
            return await _postReposiotry.CreateAsync(_mapper.Map<Post>(request), cancellationToken);
        }
    }
}
