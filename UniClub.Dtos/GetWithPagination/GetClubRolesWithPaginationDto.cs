using MediatR;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetClubRolesWithPaginationDto : RequestPaginationQuery<ClubRoleProperties?>, IRequest<PaginatedList<ClubRoleDto>>
    {
        public override ClubRoleProperties? OrderBy { get; set; }
    }
}
