using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Delete.Specifications;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostDto, int>
    {
        private readonly IPostRepository _PostRepository;

        public DeletePostCommandHandler(IPostRepository PostRepository)
        {
            _PostRepository = PostRepository;
        }

        public async Task<int> Handle(DeletePostDto request, CancellationToken cancellationToken)
        {
            var entity = await _PostRepository.GetByIdAsync(cancellationToken, new DeletePostCommandSpecification(request));
            return await _PostRepository.DeleteAsync(entity, cancellationToken);
        }
    }
}
