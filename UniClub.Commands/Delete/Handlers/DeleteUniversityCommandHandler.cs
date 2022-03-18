using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Delete.Specifications;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteUniversityCommandHandler : IRequestHandler<DeleteUniversityDto, int>
    {
        private readonly IUniversityRepository _universityRepository;

        public DeleteUniversityCommandHandler(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public async Task<int> Handle(DeleteUniversityDto request, CancellationToken cancellationToken)
        {
            var entity = await _universityRepository.GetByIdAsync(cancellationToken, new DeleteUniversityCommandSpecification(request));
            return await _universityRepository.DeleteAsync(entity, cancellationToken);
        }
    }
}
