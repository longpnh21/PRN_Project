using MediatR;
using System;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetEventsWithPaginationDto : RequestPaginationQuery<EventProperties?>, IRequest<PaginatedList<EventDto>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public override EventProperties? OrderBy { get; set; }
    }
}
