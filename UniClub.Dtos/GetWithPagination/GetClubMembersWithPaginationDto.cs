using MediatR;
using System;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetClubMembersWithPaginationDto : RequestPaginationQuery<MemberRoleProperties?>, IRequest<PaginatedList<MemberRoleDto>>
    {
        public int ClubPeriodId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public override MemberRoleProperties? OrderBy { get; set; }
    }
}
