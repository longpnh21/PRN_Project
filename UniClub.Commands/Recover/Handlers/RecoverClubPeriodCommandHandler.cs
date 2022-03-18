using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Commands.Recover.Specifications;
using UniClub.Dtos.Recover;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Recover.Handlers
{
    public class RecoverClubPeriodCommandHandler : IRequestHandler<RecoverClubPeriodDto, int>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;
        private readonly IMapper _mapper;

        public RecoverClubPeriodCommandHandler(IClubPeriodRepository clubPeriodRepository, IMapper mapper)
        {
            _clubPeriodRepository = clubPeriodRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RecoverClubPeriodDto request, CancellationToken cancellationToken)
        {
            var entity = await _clubPeriodRepository.GetByIdAsync(cancellationToken, new RecoverClubPeriodCommandSpecification(request));
            return await _clubPeriodRepository.RecoverAsync(entity, cancellationToken);
        }
    }
}
