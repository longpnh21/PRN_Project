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
    public class UpdatePostImageCommandHandler : IRequestHandler<UpdatePostImageDto, int>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;

        public UpdatePostImageCommandHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdatePostImageDto request, CancellationToken cancellationToken)
        {
            var entity = await _postImageRepository.GetByIdAsync(cancellationToken, new UpdatePostImageCommandSpecification(request));
            return await _postImageRepository.UpdateAsync(entity, _mapper.Map<PostImage>(request), cancellationToken);
        }
    }
}
