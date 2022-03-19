using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Razor.Filters;
using UniClub.Razor.Utils;

namespace UniClub.Razor.Pages.Clubs
{
    [AuthorizationFilter(Roles = "SchoolAdmin")]
    public class IndexModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public PaginatedList<ClubDto> Clubs { get; set; }
        [BindProperty(SupportsGet = true)]
        public GetClubsWithPaginationDto Dto { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var claims = SessionHelper.GetObjectFromJson<List<string>>(HttpContext.Session, "claims");
            if (claims == null)
            {
                return RedirectToPage("/Permission");
            }
            Dto.UniId = int.Parse(claims.FirstOrDefault(c => c.Contains("university")).Split("-")[1]);
            if (Dto.UniId < 1)
            {
                return NotFound();
            }

            var university = await Mediator.Send(new GetUniversityByIdDto(Dto.UniId));
            if (university == null)
            {
                return NotFound();
            }
            Clubs = await Mediator.Send(Dto);
            return Page();
        }
    }
}
