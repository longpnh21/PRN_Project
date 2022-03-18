using MediatR;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetUniversitiesWithPaginationDto : RequestPaginationQuery<UniversityProperties?>, IRequest<PaginatedList<UniversityDto>>
    {
        public override UniversityProperties? OrderBy { get; set; }
    }
}
