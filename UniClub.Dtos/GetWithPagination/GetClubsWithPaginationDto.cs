using MediatR;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetClubsWithPaginationDto : RequestPaginationQuery<ClubProperties?>, IRequest<PaginatedList<ClubDto>>
    {
        [Required]
        public int UniId { get; set; }
        public override ClubProperties? OrderBy { get; set; }
    }
}
