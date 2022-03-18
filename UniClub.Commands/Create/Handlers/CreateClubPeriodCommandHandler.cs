using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateClubPeriodCommandHandler : IRequestHandler<CreateClubPeriodDto, int>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;
        private readonly IMapper _mapper;

        public CreateClubPeriodCommandHandler(IClubPeriodRepository clubPeriodRepository, IMapper mapper)
        {
            _clubPeriodRepository = clubPeriodRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubPeriodDto request, CancellationToken cancellationToken)
        {
            return await _clubPeriodRepository.CreateAsync(_mapper.Map<ClubPeriod>(request), cancellationToken);
        }
    }
}
