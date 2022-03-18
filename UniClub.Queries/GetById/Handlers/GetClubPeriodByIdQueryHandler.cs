using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.Response;
using UniClub.Queries.GetById.Specifications;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetById.Handlers
{
    public class GetClubPeriodByIdQueryHandler : IRequestHandler<GetClubPeriodByIdDto, ClubPeriodDto>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;
        private readonly IMapper _mapper;

        public GetClubPeriodByIdQueryHandler(IClubPeriodRepository clubPeriodRepository, IMapper mapper)
        {
            _clubPeriodRepository = clubPeriodRepository;
            _mapper = mapper;
        }
        public async Task<ClubPeriodDto> Handle(GetClubPeriodByIdDto request, CancellationToken cancellationToken)
        {
            var x = await _clubPeriodRepository.GetByIdAsync(cancellationToken, new GetClubPeriodByIdQuerySpecification(request));
            return _mapper.Map<ClubPeriodDto>(await _clubPeriodRepository.GetByIdAsync(cancellationToken, new GetClubPeriodByIdQuerySpecification(request)));
        }
    }
}
