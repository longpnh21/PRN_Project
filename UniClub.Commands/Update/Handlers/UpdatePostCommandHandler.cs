using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Update.Specifications;
using UniClub.Domain.Entities;
using UniClub.Dtos.Update;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Update.Handlers
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostDto, int>
    {
        private readonly IPostRepository _PostRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository PostRepository, IMapper mapper)
        {
            _PostRepository = PostRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdatePostDto request, CancellationToken cancellationToken)
        {
            var entity = await _PostRepository.GetByIdAsync(cancellationToken, new UpdatePostCommandSpecification(request));
            return await _PostRepository.UpdateAsync(entity, _mapper.Map<Post>(request), cancellationToken);
        }
    }
}
