using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Razor.Filters;
using UniClub.Razor.Utils;

namespace UniClub.Razor.Pages.MemberRoles
{
    [AuthorizationFilter(Roles = "ClubAdmin")
    public class IndexModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public PaginatedList<MemberRoleDto> MemberRoles { get; set; }
        [BindProperty(SupportsGet = true)]
        public GetClubMembersWithPaginationDto Dto { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            
            if (Dto.ClubPeriodId < 1)
            {
                return NotFound();
            }

            var clubPeriod = await Mediator.Send(new GetClubPeriodByIdDto(Dto.ClubPeriodId));
            if (clubPeriod == null)
            {
                return NotFound();
            }
            MemberRoles = await Mediator.Send(Dto);
            return Page();
        }
    }
}
