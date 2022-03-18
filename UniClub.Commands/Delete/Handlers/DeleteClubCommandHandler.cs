using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Delete.Specifications;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteClubCommandHandler : IRequestHandler<DeleteClubDto, int>
    {
        private readonly IClubRepository _clubRepository;

        public DeleteClubCommandHandler(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public async Task<int> Handle(DeleteClubDto request, CancellationToken cancellationToken)
        {
            var entity = await _clubRepository.GetByIdAsync(cancellationToken, new DeleteClubCommandSpecification(request));
            return await _clubRepository.DeleteAsync(entity, cancellationToken);
        }
    }
}
