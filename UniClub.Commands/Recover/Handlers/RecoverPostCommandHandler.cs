using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Recover.Specifications;
using UniClub.Dtos.Recover;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverPostCommandHandler : IRequestHandler<RecoverPostDto, int>
    {
        private readonly IPostRepository _PostRepository;
        private readonly IMapper _mapper;

        public RecoverPostCommandHandler(IPostRepository PostRepository, IMapper mapper)
        {
            _PostRepository = PostRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RecoverPostDto request, CancellationToken cancellationToken)
        {
            var entity = await _PostRepository.GetByIdAsync(cancellationToken, new RecoverPostCommandSpecification(request));
            return await _PostRepository.RecoverAsync(entity, cancellationToken);
        }
    }
}
