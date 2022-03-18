using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;

namespace UniClub.Razor.Pages.Clubs
{
    public class IndexModel : PageModel
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public PaginatedList<ClubDto> Clubs { get; set; }
        [BindProperty(SupportsGet = true)]
        public GetClubsWithPaginationDto Dto { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
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
