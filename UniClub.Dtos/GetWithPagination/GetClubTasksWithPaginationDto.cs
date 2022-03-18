using MediatR;
using System;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetClubTasksWithPaginationDto : RequestPaginationQuery<ClubTaskProperties?>, IRequest<PaginatedList<ClubTaskDto>>
    {

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public override ClubTaskProperties? OrderBy { get; set; }
    }
}
