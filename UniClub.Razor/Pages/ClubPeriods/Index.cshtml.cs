using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Razor.Filters;

namespace UniClub.Razor.Pages.ClubPeriods
{
    [AuthorizationFilter(Roles = "SchoolAdmin")]
    public class IndexModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public PaginatedList<ClubPeriodDto> ClubPeriods { get; set; }
        [BindProperty(SupportsGet = true)]
        public GetClubPeriodsWithPaginationDto Dto { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Dto.ClubId < 1)
            {
                return NotFound();
            }

            var club = await Mediator.Send(new GetClubByIdDto(Dto.ClubId));
            if (club == null)
            {
                return NotFound();
            }
            ClubPeriods = await Mediator.Send(Dto);
            return Page();
        }
    }
}
