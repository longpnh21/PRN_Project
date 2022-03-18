using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Queries.GetWithPagination.Specifications;
using UniClub.Repositories.Interfaces;

namespace UniClub.Queries.GetWithPagination.Handlers
{
    public class GetClubPeriodsWithPaginationQueryHandler : IRequestHandler<GetClubPeriodsWithPaginationDto, PaginatedList<ClubPeriodDto>>
    {
        private readonly IClubPeriodRepository _clubPeriodRepository;
        private readonly IMapper _mapper;

        public GetClubPeriodsWithPaginationQueryHandler(IClubPeriodRepository clubPeriodRepository, IMapper mapper)
        {
            _clubPeriodRepository = clubPeriodRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ClubPeriodDto>> Handle(GetClubPeriodsWithPaginationDto request, CancellationToken cancellationToken)
        {

            var result = await _clubPeriodRepository.GetListAsync(cancellationToken, new GetClubPeriodsWithPaginationSpecification(request));
            return new PaginatedList<ClubPeriodDto>(result.Items.Select(e => _mapper.Map<ClubPeriodDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
