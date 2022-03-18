using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Delete.Specifications;
using UniClub.Dtos.Delete;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteClubPeriodCommandHandler : IRequestHandler<DeleteClubPeriodDto, int>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;

        public DeleteClubPeriodCommandHandler(IClubPeriodRepository clubPeriodRepository)
        {
            _clubPeriodRepository = clubPeriodRepository;
        }

        public async Task<int> Handle(DeleteClubPeriodDto request, CancellationToken cancellationToken)
        {
            var result = await _clubPeriodRepository.GetByIdAsync(cancellationToken, new DeleteClubPeriodCommandSpecification(request));
            return await _clubPeriodRepository.DeleteAsync(result, cancellationToken);
        }
    }
}
