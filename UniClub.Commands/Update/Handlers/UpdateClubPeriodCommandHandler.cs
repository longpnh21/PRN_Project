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
    public class UpdateClubPeriodCommandHandler : IRequestHandler<UpdateClubPeriodDto, int>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;
        private readonly IMapper _mapper;

        public UpdateClubPeriodCommandHandler(IClubPeriodRepository clubPeriodRepository, IMapper mapper)
        {
            _clubPeriodRepository = clubPeriodRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateClubPeriodDto request, CancellationToken cancellationToken)
        {
            var entity = await _clubPeriodRepository.GetByIdAsync(cancellationToken, new UpdateClubPeriodCommandSpecification(request));
            return await _clubPeriodRepository.UpdateAsync(entity, _mapper.Map<ClubPeriod>(request), cancellationToken);
        }
    }
}
