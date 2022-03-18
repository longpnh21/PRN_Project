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
    public class GetClubTasksWithPaginationQueryHandler : IRequestHandler<GetClubTasksWithPaginationDto, PaginatedList<ClubTaskDto>>
    {
        private readonly IClubTaskRepository _clubTaskRepository;
        private readonly IMapper _mapper;

        public GetClubTasksWithPaginationQueryHandler(IClubTaskRepository clubTaskRepository, IMapper mapper)
        {
            _clubTaskRepository = clubTaskRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ClubTaskDto>> Handle(GetClubTasksWithPaginationDto request, CancellationToken cancellationToken)
        {
            var result = await _clubTaskRepository.GetListAsync(cancellationToken, new GetClubTaskWithPaginationSpecification(request));
            return new PaginatedList<ClubTaskDto>(result.Items.Select(e => _mapper.Map<ClubTaskDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
