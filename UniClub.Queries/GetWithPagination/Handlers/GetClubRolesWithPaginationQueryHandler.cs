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
    public class GetClubRolesWithPaginationQueryHandler : IRequestHandler<GetClubRolesWithPaginationDto, PaginatedList<ClubRoleDto>>
    {
        private readonly IClubRoleRepository _clubRoleRepository;
        private readonly IMapper _mapper;

        public GetClubRolesWithPaginationQueryHandler(IClubRoleRepository clubRoleRepository, IMapper mapper)
        {
            _clubRoleRepository = clubRoleRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ClubRoleDto>> Handle(GetClubRolesWithPaginationDto request, CancellationToken cancellationToken)
        {

            var result = await _clubRoleRepository.GetListAsync(cancellationToken, new GetClubRolesWithPaginationSpecification(request));
            return new PaginatedList<ClubRoleDto>(result.Items.Select(e => _mapper.Map<ClubRoleDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
