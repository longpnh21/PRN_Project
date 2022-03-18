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
    public class GetClubsWithPaginationQueryHandler : IRequestHandler<GetClubsWithPaginationDto, PaginatedList<ClubDto>>
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMapper _mapper;

        public GetClubsWithPaginationQueryHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ClubDto>> Handle(GetClubsWithPaginationDto request, CancellationToken cancellationToken)
        {
            var result = await _clubRepository.GetListAsync(cancellationToken, new GetClubsWithPaginationSpecification(request));
            return new PaginatedList<ClubDto>(result.Items.Select(e => _mapper.Map<ClubDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
