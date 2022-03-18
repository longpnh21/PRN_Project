using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums.Properties;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetWithPagination
{
    public class GetClubPeriodsWithPaginationDto : RequestPaginationQuery<ClubPeriodProperties?>, IRequest<PaginatedList<ClubPeriodDto>>
    {
        [Required]
        public int ClubId { get; set; }
        public override ClubPeriodProperties? OrderBy { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
