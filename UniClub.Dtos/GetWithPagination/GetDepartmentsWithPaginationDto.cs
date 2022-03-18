using MediatR;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetDepartmentsWithPaginationDto : RequestPaginationQuery<DepartmentProperties?>, IRequest<PaginatedList<DepartmentDto>>
    {
        [Required]
        public int UniId { get; set; }
        public override DepartmentProperties? OrderBy { get; set; }
    }
}
