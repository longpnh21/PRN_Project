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
    public class GetClubMembersWithPaginationQueryHandler : IRequestHandler<GetClubMembersWithPaginationDto, PaginatedList<MemberRoleDto>>
    {
        private readonly IMemberRoleRepository _memberRoleRepository;
        private readonly IMapper _mapper;

        public GetClubMembersWithPaginationQueryHandler(IMemberRoleRepository memberRoleRepository, IMapper mapper)
        {
            _memberRoleRepository = memberRoleRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<MemberRoleDto>> Handle(GetClubMembersWithPaginationDto request, CancellationToken cancellationToken)
        {
            var result = await _memberRoleRepository.GetListAsync(cancellationToken, new GetMembersInClubPeriodsWithPaginationSpecification(request));
            return new PaginatedList<MemberRoleDto>(result.Items.Select(e => _mapper.Map<MemberRoleDto>(e)).ToList(), result.Count, request.PageNumber, request.PageSize);
        }
    }
}
